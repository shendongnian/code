        public void Foo()
        {
            #if !DEBUG
            try
            #endif
            {
                //Code goes here
            }
            #if !DEBUG
            catch (Exception e)
            {
                //Execption code here
            }
            #endif
        }
