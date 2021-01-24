    public partial class MainWindow : Window
    {
        public ICollection<ItemViewModel> Items { get; set; }
        public MainWindow()
        {
            Items = new List<ItemViewModel>()
            {
                new ItemViewModel()
                {
                    Name="First element",
                    HintText="First font",
                    HintFontFamily="Lucida Handwriting"
                },
                new ItemViewModel(){
                   Name="Second element",
                    HintText="Second font",
                    HintFontFamily="Track"
                }
            };
            //set the datacontext which is the binding source
            DataContext = this;
        }
    }
