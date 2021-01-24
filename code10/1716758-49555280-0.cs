        ObservableCollection<ListBoxArticle> myList = new ObservableCollection<ListBoxArticle>();
        public MainWindow()
        {
            InitializeComponent();
             MYFun();
        }
        private async Task MYFun()
        {
            myList.Add(new ListBoxArticle { Article = "my", Chap = 1, IsChecked = true, Somme = 1 });
            ToConfirm.ItemsSource = myList;
            await Task.Delay(4000);
            myList.Add(new ListBoxArticle { Article = "my", Chap = 2, IsChecked = true, Somme = 2 });
        }
    }
