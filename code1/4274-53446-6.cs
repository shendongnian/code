    public abstract class MyObjects<T> where T : IOtherObjects
    {
        List<T> _objects = new List<T>();
        public List<T> ToList()
        {
            return _objects;
        }
        public List<IOtherObjects> ToBaseList()
        {
            List<IOtherObjects> rtn = new List<IOtherObjects>();
            foreach (IOtherObjects o in _objects)
            {
                rtn.Add(o);
            }
            return rtn;
        }
    }
