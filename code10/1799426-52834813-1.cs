        private ObservableCollection<ApplicationUser> firstMGWChannel;
        public ObservableCollection<ApplicationUser> FirstMGWChannel
        {
            get
            {
                return new ObservableCollection<ApplicationUser>() { MGWChannels[0] };
            }
        }
