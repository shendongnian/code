           public void Method1()
           {
                int method3Result;    
                Method2(value => method3Result = value);
            }
            public void Method2(Action<int> callback)
            {
                Method3(callback);
            }
            public void Method3(Action<int> callback)
            {
                callback(3);
            }
        }
