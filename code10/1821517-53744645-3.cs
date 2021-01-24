     [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Sensor : ContentPage
    {
        SensorVM vm;
        public Sensor()
        {
            InitializeComponent();
            BindingContext = vm = new SensorVM();
        }
    }
