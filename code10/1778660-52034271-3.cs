    using System;
    using System.Linq;
    public static class Extensions 
    {
        public static void Add<T>(this T[] _self, T item)
        {
            if(Array.IndexOf(_self, item)== -1)
            {
                Array.Resize(ref _self, _self.Length + 1);
                _self[_self.Length - 1] = item;
            }
        }
    }
    
