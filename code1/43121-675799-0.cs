    public class Option<T>
    {
        string _msg = "";
        T _item;
      
        public bool IsNone
        {
            get { return _msg != "" ? true : false; }
        }
       
        public string Msg
        {
            get { return _msg; }
        }
        internal Option(T item)
        {
            this._item = item;
            this._msg = "";
        }
        internal Option(string msg)
        {
            if (String.IsNullOrEmpty(msg))
                throw new ArgumentNullException("msg");
            this._msg = msg;
        }
        internal T Get()
        {
            if (this.IsNone)
                throw new Exception("Cannot call Get on a NONE instance.");
           
            return this._item;
        }
        public override string ToString()
        {
            if (this.IsNone)
                return String.Format("IsNone : {0}, {1}", this.IsNone, typeof(T).Name);
            else 
                return String.Format("IsNone : {0}, {1}, {2}", this.IsNone, typeof(T).Name, this._item.ToString());
        }
