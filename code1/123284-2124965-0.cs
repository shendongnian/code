    public partial class MyControl : UserControl
    {
       MyProject.Properties.Settings config_;
       public MyControl 
       {
          InitializeComponent();
          config_ = new MyProject.Properties.Settings();
       }
       public void SaveToConfig()
       {
          // save to configuration file
          config_.ReportFileName = dataFileName.Text;
          config_.Save();
       }
       public void LoadFromConfig()
       {
          string dataFileName = config_.ReportFileName;
       } 
    } 
