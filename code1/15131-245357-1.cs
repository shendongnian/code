    class Remover
    {
        // .net 1.1 must cast if assigning
        public static object Remove(object x)
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(x);
            return null;
        }
        // uses generics.
        public static ComT RemoveCom<ComT>(ComT t) where ComT : class
        {
            System.Runtime.InteropServices.Marshal.ReleaseComObject(t);
            return null;
        }   
    }
    Com1 c1 = new Com1();
    Com2 c2 = new Com2();
    c1 = (Com1)Remover.Remove(c1); // no reliance on generics
    c2 = Remover.RemoveCom(c2); // relies on generics
