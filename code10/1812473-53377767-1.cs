    public class Zoo
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
    }
    public class CarouselViewModel : ViewModelBase
    {
        private ObservableCollection<Zoo> zoos;
        public ObservableCollection<Zoo> Zoos
        {
            get => zoos; set => SetProperty(ref zoos, value);
        }
        public CarouselViewModel()
        {
            zoos = new ObservableCollection<Zoo>
            {
                new Zoo
                {
                    ImageUrl = "http://content.screencast.com/users/JamesMontemagno/folders/Jing/media/23c1dd13-333a-459e-9e23-c3784e7cb434/2016-06-02_1049.png",
                    Name = "Woodland Park Zoo"
                },
                    new Zoo
                {
                    ImageUrl =    "http://content.screencast.com/users/JamesMontemagno/folders/Jing/media/6b60d27e-c1ec-4fe6-bebe-7386d545bb62/2016-06-02_1051.png",
                    Name = "Cleveland Zoo"
                    },
                new Zoo
                {
                    ImageUrl = "http://content.screencast.com/users/JamesMontemagno/folders/Jing/media/e8179889-8189-4acb-bac5-812611199a03/2016-06-02_1053.png",
                    Name = "Phoenix Zoo"
                }
            };
        }
    }
    public partial class MainPage : ContentPage
    {
        public CarouselViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = viewModel = new CarouselViewModel();
        }
    }
