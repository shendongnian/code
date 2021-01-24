    public class MainViewModel
    {
        public MainViewModel()
        {
            DataItems = new List<DataItem>();
            for (var i = 1; i <= 20; i++)
                _dataItemList.Add(new DataItem());
        }
        public List<DataItem> DataItems {get;}
    }
