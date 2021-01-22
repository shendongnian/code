    public partial class NWDataContext
    {
        partial void InsertCategory(Category instance)
        {
            if(Instance.Date == null)
                Instance.Data = DateTime.Now;
    
            ExecuteDynamicInsert(instance);
        }
    }
