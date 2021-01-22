    public static class MyContextProvider
        {
            public static MyModel Context
            {
                get
                {
                    if (HttpContext.Current.Items["context"].IsNull())
                    {
                        HttpContext.Current.Items["context"] = new MyModel();
                    }
    
                    return HttpContext.Current.Items["context"] as MyModel;
                }
            }    
        }
