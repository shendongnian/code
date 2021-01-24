	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FieldView : ContentView
    {
        public FieldView()
        {
            InitializeComponent();
            // Here you set the Resources property through your method
            Resources = GetResources();
        }
        protected virtual ResourceDictionary GetResources()
        {
            ResourceDictionary ret = new ResourceDictionary();
            // Create your style here
            Style labelStyle = new Style(typeof(Label));
            labelStyle.Setters.Add(new Setter() { Property = Label.FontSizeProperty, Value = 20 });
            // Add the style to Resource Dictionary
            ret.Add("LabelStyle", labelStyle);
            
            // Return the resource Dictionary
            return ret;
        }
    }
