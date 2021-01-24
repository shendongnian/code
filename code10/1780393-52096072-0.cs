    CSV csv = new CSV();
    public MainWindow()
    {
    	InitializeComponent();
    	Main.Content = new LoadCSVPage(csv);
    }
    public class LoadCSVPage
    {
    	private CSV _csv;
    
    	public LoadCSVPage(CSV mainCsv)
        {
            InitializeComponent();
    		_csv = mainCsv;
        }
        private void LoadCSV_DragEnter(object sender, DragEventArgs e)
        {
            string filePath = "";
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                filePath = file;
            }
           // Here the csv object can obtain the filePath
    		_csv.SetLocation(filePath);
    	}
    }
