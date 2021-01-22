    public class ListObject
    {
        public DataRow element;
        public String DisplayObject = null;
        public ListObject(DataRow dr)
        {
            element = dr;
        }
        public ListObject(DataRow dr, String dspObject)
        {
            element = dr;
            DisplayObject = dspObject;
        }
        public override String ToString()
        {
            if (DisplayObject == null) throw new Exception("DisplayObject property was not set.");
            return element[DisplayObject].ToString();
        }
        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(ListObject))
                return Equals(((ListObject)obj).element, this.element);
            else return base.Equals(obj);
        }
        
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
