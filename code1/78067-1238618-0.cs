    class Parent
    {
        private void parent_Adduser()
        {
            // ...
        }
        protected abstract void child_Adduser();
        public void Adduser()
        {
            parent_Adduser();
            child_Adduser();
        }
    }
    class Child
    {
        protected override void child_Adduser()
        {
            // ...
        }
    }
