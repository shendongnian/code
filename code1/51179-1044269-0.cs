    public interface IValueDescritionItem
    {
        int Value { get; set;}
        string Description { get; set;}
    }
    
    public class MyItem : IValueDescritionItem
    {
        HowNice _howNice;
        string _description;
        public MyItem()
        {
        }
        public MyItem(HowNice howNice, string howNice_descr)
        {
            _howNice = howNice;
            _description = howNice_descr;
        }
        public HowNice Niceness { get { return _howNice; } }
        public String NicenessDescription { get { return _description; } }
        #region IValueDescritionItem Members
        int IValueDescritionItem.Value
        {
            get { return (int)_howNice; }
            set { _howNice = (HowNice)value; }
        }
        string IValueDescritionItem.Description
        {
            get { return _description; }
            set { _description = value; }
        }
        #endregion
    }
