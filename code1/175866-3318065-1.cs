      object mCachedValue = null;
        public Object MyProperty
        {
            get
            {
                if (mCachedValue == null)
                {
                   lock(mCachedValue)
                    {
                       //after acquiring the lock check if the property has not been initialized in the mean time - only calculate once
                        if (mCachedValue == null)
                        {
                            //calculate value the first time 
                        }
                    }
                }
                return mCachedValue;
            }
   
