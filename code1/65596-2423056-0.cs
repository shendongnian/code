    public class C {
    
        double v;
    
        public static void Main() {
            var test =
                new List<C> { new C { v = 0d },
                              new C { v = Double.NaN },
                              new C { v = 1d } };
            test.Sort((d1, d2) => (int)(d1.v - d2.v));
        }
    
    }
