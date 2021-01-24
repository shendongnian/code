    public CSV csv = new CSV();
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
            //foreach (string file in files)
            //{
                //This also is not really clear: what happen if you drag more then one file? 
                //This way you are cycling for each file, but you are selecting the last` 
                //filePath = file;
            //}
           if(files.Length > 0)
           {
               filePath = files.Last();
           }
           // Here the csv object can obtain the filePath
    	   _csv.SetLocation(filePath);
           
    	}
    }
