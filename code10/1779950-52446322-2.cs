    public interface IMatterListLoader
    {
        IReadOnlyCollection<ClientMatter> Load(FileInfo fromFile);
        IDictionary<string, object> Properties { get; }
        void SetProperties(IDictionary<string, object> properties);
    }
    
    public sealed class AsciiMatterListLoader : IMatterListLoader
    {
        public IReadOnlyCollection<string> MatterListFileExtensions { get; set; }
    
        public IDictionary<string, object> Properties
        {
            get 
            {
                return new Dictionary<string, object>(); // Don't need any parameters for ascii files
            }
        }
    
        public void SetProperties(IDictionary<string, object> properties)
        {
            // Nothing to do
        }
    
        public IReadOnlyCollection<ClientMatter> Load(FileInfo fromFile)
        {
            // Load without using any additional params
            return null;
        }
    }
    
    public sealed class ExcelMatterListLoader : IMatterListLoader
    {
        private const string StartRowNumParam = "StartRowNum";
        private const string StartColNumParam = "StartColNum";
    
        public uint StartRowNum { get; set; }
        public uint StartColNum { get; set; }
        public IReadOnlyCollection<string> MatterListFileExtensions { get; set; }
    
        private bool havePropertiesBeenSet = false;
    
        public IDictionary<string, object> Properties
        {
            get
            {
                var properties = new Dictionary<string, object>();
                properties.Add(StartRowNumParam, (uint)0); // Give default UINT value so UI knows what type this property is
                properties.Add(StartColNumParam, (uint)0); // Give default UINT value so UI knows what type this property is
    
                return properties;
            }
        }
    
        public void SetProperties(IDictionary<string, object> properties)
        {
            if (properties != null)
            {
                foreach(var property in properties)
                {
                    switch(property.Key)
                    {
                        case StartRowNumParam:
                            this.StartRowNum = (uint)property.Value;
                            break;
                        case StartColNumParam:
                            this.StartColNum = (uint)property.Value;
                            break;
                        default:
                            break;
                    }
                }
    
                this.havePropertiesBeenSet = true;
            }
            else
                throw new ArgumentNullException("properties");
        }
    
        public IReadOnlyCollection<ClientMatter> Load(FileInfo fromFile)
        {
            if (this.havePropertiesBeenSet)
            {
                // Load using StartRowNum and StartColNum
                return null;
            }
            else
                throw new Exception("Must call SetProperties() before calling Load()");
        }
    }
    
    public sealed class MainViewModel
    {
        public string InputFilePath { get; set; }
        public ICommandExecutor LoadClientMatterListCommand { get; }
        private IMatterListLoader matterListLoader;
    
        public MainViewModel(IMatterListLoader matterListLoader)
        {
            this.matterListLoader = matterListLoader;
    
            if (matterListLoader != null && matterListLoader.Properties != null)
            {
                foreach(var prop in matterListLoader.Properties)
                {
                    if (typeof(prop.Value) == typeof(DateTime))
                    {
                        // Draw DateTime picker for datetime value
                        this.placeHolderPanelForParams.Add(new DateTimePicker() { Name = prop.Key });
                    }
                    else 
                    {
                        // Draw textbox for everything else
                        this.placeHolderPanelForParams.Add(new TextBox() { Name = prop.Key });
    
                        // You can also add validations to the input here (E.g. Dont allow negative numbers of prop is unsigned)
                        // ...
                    }
                }
            }
        }
    
        public void LoadFileButtonClick(object sender, EventArgs e)
        {
            //Get input params from UI
            Dictionary<string, object> properties = new Dictionary<string, object>();
            foreach(Control propertyControl in this.placeHolderPanelForParams().Children())
            {
                if (propertyControl is TextBox)
                    properties.Add(propertyControl.Name, ((TextBox)propertyControl).Text);
                else if (propertyControl is DateTimePicker)
                    properties.Add(propertyControl.Name, ((DateTimePicker)propertyControl).Value);
            }
    
            this.matterListLoader.SetProperties(properties);
            this.matterListLoader.Load(null); //Ready to load
        }
    }
