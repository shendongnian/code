    private ObservableCollection<ByteData> _collection = new ObservableCollection<ByteData>();
	public Window1()
	{
		InitializeComponent();
		_collection.Add(new ByteData(new byte[] { 12, 54 }));
		_collection.Add(new ByteData(new byte[] { 1, 2, 3, 4, 5 }));
		_collection.Add(new ByteData(new byte[] { 15 }));
	}
	public ObservableCollection<ByteData> ObservableCollection
	{
		get { return _collection; }
	}
	public class ByteData
	{
		byte[] _data;
		public ByteData(byte[] data)
		{
			_data = data;
		}
		public byte[] Data
		{
			get { return _data; }
			set { _data = value; }
		}
	}
