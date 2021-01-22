       public MainWindow()
        {
            this.InitializeComponent();    
            doubleclickevent();
        }
    
        private void doubleclickevent()
           {
       
           string[] args = Environment.GetCommandLineArgs();
           string[] arr = new string[]
                        {
                        ".MP4",
                        ".MKV",
                        ".AVI"
                        };
    
        foreach (string element in args)
                {
                    foreach (string s in arr)
                    {
                        if (element.EndsWith(s))
                        {
                        MediaElement.Source = new Uri(@element, UriKind.RelativeOrAbsolute);
                        MediaElement.LoadedBehavior = MediaState.Play;
                        }
                        else { return; }
                    }
                }
        
          }
