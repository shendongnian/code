    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChildView : FieldView
    {
        public ChildView()
        {
            InitializeComponent();
			// Call the same method
            Resources = GetResources();
        }
		
        protected override ResourceDictionary GetResources()
        {
            ResourceDictionary res = base.GetResources();
            // You can add new Styles here, for example
            Style newStyle = new Style(typeof(Button));
            newStyle.Setters.Add(new Setter() { Property = Button.BackgroundColorProperty, Value = Color.Red });
            res.Add("DangerButtonStyle", newStyle);
            return res;
        }
    }
