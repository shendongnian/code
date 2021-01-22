        using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using QDAL.CoreContext;
    using QDAL.CoreEntities;
    using LinqExtension.CustomExtensions;
    namespace QDAL
    {
        internal class DisconnectedEntitySaver
        {
            private QDataDataContext ContextForUpdate;
            public DisconnectedEntitySaver() {
                ContextForUpdate = Base.CreateDataContext();
            }
            public List<TEntityType> SaveEntities<TEntityType, TKeyType>(List<TEntityType> EntitiesToSave) {
                string PKName;
                PKName = Base.GetPrimaryKeyName(typeof(TEntityType), ContextForUpdate);
                return SaveEntities<TEntityType, TKeyType>(EntitiesToSave, PKName);
            }
            public List<TEntityType> SaveEntities<TEntityType, TKeyType>(List<TEntityType> EntitiesToSave, string KeyFieldName)
            {
                List<TEntityType> EntitiesToPossiblyUpdate;
                List<TEntityType> EntitiesToInsert;
                List<TEntityType> HandledEntities = new List<TEntityType>();
             
                bool TimeStampEntity;
                Type ActualFieldType;
                if (EntitiesToSave.Count > 0) {
                    TimeStampEntity = Base.EntityContainsTimeStamp(typeof(TEntityType), ContextForUpdate);
                    ActualFieldType = EntitiesToSave.FirstOrDefault().GetPropertyType(KeyFieldName);
                    if (ActualFieldType != typeof(TKeyType)) {
                        throw new Exception("The UniqueFieldType[" + typeof(TKeyType).Name + "] specified does not match the actual field Type[" + ActualFieldType.Name + "]");
                    }
                    if (ActualFieldType == typeof(string)) {
                        EntitiesToPossiblyUpdate = EntitiesToSave.Where(ent => string.IsNullOrEmpty(ent.GetPropertyValue<string>(KeyFieldName)) == false).ToList();
                        EntitiesToInsert = EntitiesToSave.Where(ent => string.IsNullOrEmpty(ent.GetPropertyValue<string>(KeyFieldName)) == true).ToList();
                    } else {
                        EntitiesToPossiblyUpdate = EntitiesToSave.Where(ent => EqualityComparer<TKeyType>.Default.Equals(ent.GetPropertyValue<TKeyType>(KeyFieldName), default(TKeyType)) == false).ToList();
                        EntitiesToInsert = EntitiesToSave.Where(ent => EqualityComparer<TKeyType>.Default.Equals(ent.GetPropertyValue<TKeyType>(KeyFieldName), default(TKeyType)) == true).ToList();
                    }
                    if (EntitiesToPossiblyUpdate.Count > 0) {
                        EntitiesToInsert.AddRange(ResolveUpdatesReturnInserts<TEntityType, TKeyType>(EntitiesToPossiblyUpdate, KeyFieldName));
                        HandledEntities.AddRange(EntitiesToPossiblyUpdate.Where(ent => EntitiesToInsert.Select(eti => eti.GetPropertyValue<TKeyType>(KeyFieldName)).Contains(ent.GetPropertyValue<TKeyType>(KeyFieldName)) == false));
                    }
                    if (EntitiesToInsert.Count > 0) {
                        ContextForUpdate.GetTable(typeof(TEntityType)).InsertAllOnSubmit(EntitiesToInsert);
                        HandledEntities.AddRange(EntitiesToInsert);
                    }
                    ContextForUpdate.SubmitChanges();
                    ContextForUpdate = null;
                    return HandledEntities;
                } else {
                    return EntitiesToSave;
                }
            }
            private List<TEntityType> ResolveUpdatesReturnInserts<TEntityType, TKeyType>(List<TEntityType> PossibleUpdates, string KeyFieldName)
            {
                QDataDataContext ContextForOrginalEntities;
                List<TKeyType> EntityToSavePrimaryKeys;
                List<TEntityType> EntitiesToInsert = new List<TEntityType>();
                List<TEntityType> OriginalEntities;
                TEntityType NewEntityToUpdate;
                TEntityType OriginalEntity;
                string TableName;
                ContextForOrginalEntities = Base.CreateDataContext();
                TableName = ContextForOrginalEntities.Mapping.GetTable(typeof(TEntityType)).TableName;
                EntityToSavePrimaryKeys = (from ent in PossibleUpdates select ent.GetPropertyValue<TKeyType>(KeyFieldName)).ToList();
                OriginalEntities = ContextForOrginalEntities.ExecuteQuery<TEntityType>("SELECT * FROM " + TableName + " WHERE " + KeyFieldName + " IN('" + string.Join("','", EntityToSavePrimaryKeys.Select(varobj => varobj.ToString().Trim()).ToArray()) + "')").ToList();
                //kill original entity getter
                ContextForOrginalEntities = null;
                foreach (TEntityType NewEntity in PossibleUpdates)
                {
                    NewEntityToUpdate = NewEntity;
                    OriginalEntity = OriginalEntities.Where(ent => EqualityComparer<TKeyType>.Default.Equals(ent.GetPropertyValue<TKeyType>(KeyFieldName),NewEntityToUpdate.GetPropertyValue<TKeyType>(KeyFieldName)) == true).FirstOrDefault();
                    if (OriginalEntity == null)
                    {
                        EntitiesToInsert.Add(NewEntityToUpdate);
                    }
                    else
                    {
                        ContextForUpdate.GetTable(typeof(TEntityType)).Attach(CloneEntity<TEntityType>(NewEntityToUpdate), OriginalEntity);
                    }
                }
                return EntitiesToInsert;
            }
            
            protected  TEntityType CloneEntity<TEntityType>(TEntityType EntityToClone)
            {
                var dcs = new System.Runtime.Serialization.DataContractSerializer(typeof(TEntityType));
                using (var ms = new System.IO.MemoryStream())
                {
                    dcs.WriteObject(ms, EntityToClone);
                    ms.Seek(0, System.IO.SeekOrigin.Begin);
                    return (TEntityType)dcs.ReadObject(ms);
                }
            }
        }
    }
