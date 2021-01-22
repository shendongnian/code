    public class DataObjectWithBarValue : BaseDataObject
    {
        public void BarValue
        {
            set
            {
                SetData("bar", value);
            }
            get
            {
                (int) GetData("bar");
            }
        }
    }
