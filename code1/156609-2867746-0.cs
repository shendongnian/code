    class A
    {
        public A()
        {
            ExampleB.StatusUpdate += new EventHandler<ExampleArgs>(ExampleB_StatusUpdate);
        }
        void ExampleB_StatusUpdate(object sender, ExampleArgs e)
        {
            UpdateUI();
        }
        public B ExampleB { get; set; }
        public event EventHandler<ExampleArgs> StatusUpdate;
        protected virtual void OnChanged(ExampleArgs e)
        {
            if (StatusUpdate != null)
            {
                StatusUpdate(this, e);
            }
        }
    }
    class B
    {
        public B()
        {
            ExampleC.StatusUpdate += new EventHandler<ExampleArgs>(ExampleC_StatusUpdate);
        }
        void ExampleC_StatusUpdate(object sender, ExampleArgs e)
        {
            OnChanged(e);
        }
        public C ExampleC { get; set; }
        public event EventHandler<ExampleArgs> StatusUpdate;
        protected virtual void OnChanged(ExampleArgs e)
        {
            if (StatusUpdate != null)
            {
                StatusUpdate(this, e);
            }
        }
    }
    class C
    {
        public event EventHandler<ExampleArgs> StatusUpdate;
        protected virtual void OnChanged(ExampleArgs e)
        {
            if (StatusUpdate != null)
            {
                StatusUpdate(this, e);
            }
        }
    }
    class ExampleArgs : EventArgs
    {
        public string StatusUpdate { get; set; }
    }
