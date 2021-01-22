        using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using QDAL.CoreContext;
    using QDAL.CoreEntities;
    using System.Configuration;
    namespace QDAL
    {
        internal class Base
        {
            public Base() {
            }
            internal static QDataDataContext CreateDataContext() {
                QDataDataContext newContext;
                string ConnStr;
                ConnStr = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                newContext = new QDataDataContext(ConnStr);
                return newContext;
            }
            internal static string GetTableName(Type EntityType, QDataDataContext CurrentContext) {
                return CurrentContext.Mapping.GetTable(EntityType).TableName;
            }
            internal static string GetPrimaryKeyName(Type EntityType, QDataDataContext CurrentContext) {
                return (from m in CurrentContext.Mapping.MappingSource.GetModel(CurrentContext.GetType()).GetMetaType(EntityType).DataMembers where m.IsPrimaryKey == true select m.Name).FirstOrDefault();
            }
            internal static bool EntityContainsTimeStamp(Type EntityType, QDataDataContext CurrentContext) {
                return (CurrentContext.Mapping.MappingSource.GetModel(CurrentContext.GetType()).GetMetaType(EntityType).DataMembers.Where(dm => dm.IsVersion == true).FirstOrDefault() != null);
            }
        }
    }
