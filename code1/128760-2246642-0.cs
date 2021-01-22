    public abstract class Model
    {
        public abstract void Create();
        public abstract Model Read(Guid ID);  //<--here
        public abstract void Update();
        public abstract void Delete();
    }
