            public interface IError { }
    
            public class ErrorTypeA : IError
            { public string Name; }
    
            public class ErrorTypeB : IError
            {
                public string Name;
                public int line;
            }
    
            public void CreateErrorObject()
            {
                IError error;
                if (FileNotFoundException) // put your check here
                {
                    error = new ErrorTypeA
                        {
                            Name = ""
                        };
                }
                elseif (InValidOpertionException) // put your check here
                {
                    error = new ErrorTypeB
                    {
                        Name = "",
                        line = 1
                    };
                }
            }
