    public class SampleAttribute : Attribute
    {
        private string _test;
        public SampleAttribute(string test = null)
        {
            _test = test;
        }
    }
    
    [Sample]
    public class Toto
    {
    
    }
