    object mCachedValue = null ;
            public Object MyProperty { 
                get
                {
                    if (mCachedValue == null)
                    {
                    //calculate value the first time
                    }
                    return mCachedValue ;
                }
                set; }
