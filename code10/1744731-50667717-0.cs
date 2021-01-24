    public class Foo<T>
    { 
        IEnumerable<T> _aTypes;
        public IEnumerable<T> ATypes 
        {
             get { return _aTypes; }
             set 
             {
                 //do your custom logic
                 this._aTypes = value;
             }
        }  
    }
