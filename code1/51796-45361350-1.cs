    public interface ISmartWrap
    {
        bool IsDirty { get; set; }
        void MakeClean();
        bool IsInterimDirty { get;  }
        void SetIterimDirtyState();
        void MakeCleanIfInterimClean();
    }
