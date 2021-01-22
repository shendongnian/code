    public class MyGuardedClass
    {
        private int id;
        private string name;
        private ThreadGuard guard = new ThreadGuard();
        public MyGuardedClass()
        {
        }
        public ILock Lock()
        {
            return guard.GetLock();
        }
        public override string ToString()
        {
            return string.Format("[ID: {0}, Name: {1}]", id, name);
        }
        public int ID
        {
            get { return id; }
            set
            {
                guard.BeginGuardedOperation();
                id = value;
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                guard.BeginGuardedOperation();
                name = value;
            }
        }
    }
