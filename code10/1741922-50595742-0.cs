    //I add the bool in this class, so you can change the CheckBox's state by your Data Source
    //That means that your CheckBox's state based upon your Data Source.
    public class TableList : Java.Lang.Object
    {
        public TableList(string name, bool b)
        {
            this.Name = name;
            this.bl = b;
        }
        public string Name { get; set; }
        public bool bl { get; set; }
    }
