    class SomeActionAccessor<T>
    {
        // Declare delegate and fied of delegate type.
        public delegate T GetAllNodesDelegate(int i);
        private GetAllNodesDelegate getAllNodesDlg;
        // Initilaize delegate field somehow, e.g. in constructor.
        public SomeActionAccessor(GetAllNodesDelegate getAllNodesDlg)
        {
            this.getAllNodesDlg = getAllNodesDlg;
        }
        // Implement the method that calls the delegate.
        public T GetAllNodes(int i)
        {
            return this.getAllNodesDlg(i);
        }
    }
