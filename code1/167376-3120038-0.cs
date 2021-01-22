        #region Begin/End Update
        int refcount = 0;
        ChildObject record;
        protected ChildObject ActiveRecord
        {
            get 
            {
                return record;
            }
            set 
            {
                record = value;
            }
        }
        public void BeginUpdate()
        {
            if (count == 0)
            {
                ActiveRecord = new ChildObject(1);
            }
            Interlocked.Increment(ref refcount);
        }
        public void EndUpdate()
        {
            int count = Interlocked.Decrement(ref refcount);
            if (count == 0)
            {
                ActiveRecord.Save();
            }
        }
        #endregion
        #region operations
        public void SomeFunction1()
        {
            BeginUpdate();
            try
            {
                ActiveRecord.Property1 = "blah!";
            }
            finally
            {
                EndUpdate();
            }
        }
        public void SomeFunction2()
        {
            BeginUpdate();
            try
            {
                ActiveRecord.Property2 = "blah!";
            }
            finally
            {
                EndUpdate();
            }
        }
        public void SomeFunction2()
        {
            BeginUpdate();
            try
            {
                SomeFunction1();
                SomeFunction2();
            }
            finally
            {
                EndUpdate();
            }
        } 
        #endregion
