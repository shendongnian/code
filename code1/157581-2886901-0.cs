    [Serializable]
    public class BaseDataList<T> : List<T>
        where T : BaseObject // this is the key line, it ensure that
                             // T is a BaseObject so you can call 
                             //BaseObject methods on T, should allow for you
                             //to put more implementation in this class than
                             // you could otherwise
    {
        private bool is_disposed = false;
        private bool _NeedsSaving = false;
    
        ///this assumes that key is a property on BaseObject that everything implements
        public T this[string index]
        {
            get { return this.Find(f => f.Key == index); }
            set { this[this.FindIndex(f => f.Key == index)] = value; }
        }
    
        public BaseDataList() { }
    
        // instantiates the object and connects it to the DB 
        // and populates it
        internal BaseDataList(ref DBLib.DBAccess DA)
        {
            DataSet ds = GetDataSet();
    
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                this.Add(new T(ref DA, dr));
            }
            // Destroy the dataset object
            if (ds != null)//...
        }
        //abstract methods for extensibility...
       protected abstract GetDataSet();
    }
