    interface ISaveable
    {
        void Save();
        void Insert();
        void Update();
    }
    class UserAccount : ISavable
    {
        void ISavable.Save() { ... }
        void ISavable.Insert() { ... }
        void ISavable.Update() { ... }
    }
