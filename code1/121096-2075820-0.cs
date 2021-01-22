    public class Loader
    {
        public void Load(string typename)
        {
            // ....
        }
    }
    
    Loader l = (Loader)domain.CreateInstanceAndUnwrap("Loader");
    l.Load("SomeClassInTheDll");
