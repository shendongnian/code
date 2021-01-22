            public interface IError { }
    
            public class ErrorTypeA : IError
            { public string Name;        }
    
            public class ErrorTypeB : IError
            {
                public string Name;
                public int line;
            }
    
            public void CreateErrorObject()
            {
                IError error;
                if (Exception)
                {
                    error = new ErrorTypeA
                        {
                            Name = ""
                        };
                }
                else
                {
                    error = new ErrorTypeB
                    {
                        Name = "",
                        line = 1
                    };
                }
            }
