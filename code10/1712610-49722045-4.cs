    class ClientItem
    {
        private ObservableCollection<int> test;
        public ObservableCollection<int> Test
        {
            get
            {
                return test;
            }
            set
            {
                Console.Out.WriteLine("Set");
                test = value;
            }
        }
    }
