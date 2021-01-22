    public abstract class Class1
            {
                protected const string Prefix = "dynfrm_";
            }
    
            public class Class2 : Class1
            {
                public void GetConst()
                {
                    Console.WriteLine(Prefix);
                }
            }
