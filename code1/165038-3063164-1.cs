    public interface ISavable
    {
        bool HasChanges {get;set;}
        void Save();
    }
    void Save(ISavable item)
    {
        if (item.HasChanges)
            item.Save()
    }
