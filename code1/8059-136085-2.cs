    public class SubClassedDataObject : BaseDataObject
    {
        public int Bar
        {
            get { return (int)GetData("bar"); }
            set { SetData("bar", value); }
        }
    }
