    public class ImplementingClass : AClass1, IClass1, IClass2
    
        {
            public override string Method()
            {
                return "AClass1";
            }
            string IClass1.Method()
            {
                return "IClass1";
            }
             string IClass2.Method()
            {
                return "IClass2";
            }
        }
