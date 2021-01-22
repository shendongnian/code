    partial class MyDataContext // or a base-class
    {
        public override void SubmitChanges(System.Data.Linq.ConflictMode failureMode)
        {
            this.MakeUpdatesDirty("UpdatedBy", "Updated_By");
            base.SubmitChanges(failureMode);
        }
    }
    public static class DataContextExtensions
    {
        public static void MakeUpdatesDirty(
            this DataContext dataContext,
            params string[] members)
        {
            if (dataContext == null) throw new ArgumentNullException("dataContext");
            if (members == null) throw new ArgumentNullException("members");
            if (members.Length == 0) return; // nothing to do
            foreach (object instance in dataContext.GetChangeSet().Updates)
            {
                MakeDirty(dataContext, instance, members);
            }
        }
        public static void MakeDirty(
            this DataContext dataContext, object instance ,
            params string[] members)
        {
            if (dataContext == null) throw new ArgumentNullException("dataContext");
            if (instance == null) throw new ArgumentNullException("instance");
            if (members == null) throw new ArgumentNullException("members");
            if (members.Length == 0) return; // nothing to do
            const BindingFlags AllInstance = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
            object commonDataServices = typeof(DataContext)
                .GetField("services", AllInstance)
                .GetValue(dataContext);
            object changeTracker = commonDataServices.GetType()
                .GetProperty("ChangeTracker", AllInstance)
                .GetValue(commonDataServices, null);
            object trackedObject = changeTracker.GetType()
                .GetMethod("GetTrackedObject", AllInstance)
                .Invoke(changeTracker, new object[] { instance });
            var memberCache = trackedObject.GetType()
                .GetField("dirtyMemberCache", AllInstance)
                .GetValue(trackedObject) as BitArray;
            var entityType = instance.GetType();
            var metaType = dataContext.Mapping.GetMetaType(entityType);
            for(int i = 0 ; i < members.Length ; i++) {
                var member = entityType.GetMember(members[i], AllInstance);
                if(member != null && member.Length == 1) {
                    var metaMember = metaType.GetDataMember(member[0]);
                    if (metaMember != null)
                    {
                        memberCache.Set(metaMember.Ordinal, true);
                    }
                }
            }
        }
    }
