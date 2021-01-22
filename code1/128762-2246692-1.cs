    public interface IModel
    {
        void Create();
        IModel Read(Guid ID);
        void Update();
        void Delete();
    }
