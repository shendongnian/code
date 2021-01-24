    public class HomeViewModel
    {
        public TrackParcelViewModel TrackParcelViewModel { get; set; }
        // TrackParcelViewModel only has TrackingNumber (int)
        // OTher stuff...
    
        public int NameYouLike
        {
            get => TrackParcelViewModel.TrackingNumber;
            set => TrackParcelViewModel.TrackingNumber = value;
        }
    }
