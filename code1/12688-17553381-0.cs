        class Foo
        {
            public Foo()
            {
                Go();
            }
    
            public void Go()
            {
                for (float i = float.MinValue; i < float.MaxValue; i+= 0.000000000000001f)
                {
                    byte[] b = new byte[1]; // Causes stackoverflow
                }
            }
        }
