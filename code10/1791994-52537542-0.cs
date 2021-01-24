    public partial class TrainDetailsControl : UserControl
    {
        public TrainDetailsControl()
        {
            InitializeComponent();
            Loaded += (s, e) =>
            {
                Train selectedTrain = DataContext as Train;
                if (selectedTrain != null)
                {
                    //...
                }
            };
        }
    }
