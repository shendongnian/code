    namespace App.BackEnd // classes here are used for database storage
    {
        public class X
        {
            public string abc { get; set; }
            public string def { get; set; }
            
            public FrontEnd.X ToFrontEnd()
            {
                return new FrontEnd.X
                {
                    abc = abc
                };
            }
        }
    }
    namespace App.FrontEnd // classes here are used for public interfaces
    {
        public class X
        {
            public string abc { get; set; }
        }
    }
