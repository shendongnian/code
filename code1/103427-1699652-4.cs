    public class MyDataObject : DataObject
    {
        public MyDataObject(string format, object data)
           : base(format, data) { }
        public override object GetData(string format)
        {
            MessageBox.Show("Format: "+format);
            return base.GetData(format);
        }
    }
