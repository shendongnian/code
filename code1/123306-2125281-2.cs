    class ParamHolder
    {
        private object data;
    
        public ParamHolder(object data) // better yet using the parameter(s) type
        {
            this.data = data;
        }
    
        public void DoWork()
        {
            // use data
            // do work
        }
    }
