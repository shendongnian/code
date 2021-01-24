    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();
        }
        public string TextBoxFileName => GlobalVariables.FileName;
        public string TextBoxFilePath => GlobalVariables.FilePath;
    }
