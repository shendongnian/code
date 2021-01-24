    public sealed class AsciiMatterListLoader : IMatterListLoader
    {
        public IReadOnlyCollection<string> MatterListFileExtensions { get; set; }
    
        public IReadOnlyCollection<ClientMatter> Load(FileInfo fromFile)
        {
            // load data with no parameters
        }
        
        public Panel Draw()
        {
            // Nothing needs to be drawn
            return null;
        }
    }
    
    public sealed class ExcelMatterListLoader : IMatterListLoader
    {
        public uint StartRowNum { get; set; }
        public uint StartColNum { get; set; }
        public IReadOnlyCollection<string> MatterListFileExtensions { get; set; }
    
        public IReadOnlyCollection<ClientMatter> Load(FileInfo fromFile)
        {
            // load using StartRowNum and StartColNum
        }
    
        public Panel Draw()
        {
            Panel panelForUserParams = new Panel();
            panelForUserParams.Height = 400;
            panelForUserParams.Width = 200;
            TextBox startRowTextBox = new TextBox();
            startRowTextBox.Name = "startRowTextBox";
            TextBox startColumnTextBox = new TextBox();
            startColumnTextBox.Name = "startColumnTextBox";
            panelForUserParams.Children().Add(startRowTextBox);
            panelForUserParams.Children().Add(startColumnTextBox);
            return panelForUserParams;
        }
    }
    public sealed class MainViewModel
    {
        public string InputFilePath { get; set; }
        public ICommandExecutor LoadClientMatterListCommand { get; }
    
        public MainViewModel(IMatterListLoader matterListLoader)
        {
            var panel = matterListLoader.Draw();
            if (panel != null)
            {
                    // Your MainViewModel should have a dummy empty panel called "placeHolderPanelForChildPanel"
                    var parent = this.placeHolderPanelForChildPanel.Parent;
                    parent.Children.Remove(this.placeHolderPanelForChildPanel); // Remove the dummy panel
                    parent.Children.Add(panel); // Replace with new panel
            }
        }
    }
