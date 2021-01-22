     public static CustomerController Instance
            {
                    get 
                    {
                            if( _instance == null )
                            {
                               lock(singletonLock)
                               {
                                    if( _instance == null )
                                    {
                                            _instance = new CustomerController();  
                                    }
                                    
                                }
                            }   
                            return _instance;
                    }
            }
