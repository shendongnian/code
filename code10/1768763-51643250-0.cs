          InitializeComponent();
            List<Item> items = new List<Item>();
            items.Add(new Item() { Name = "Item1", Category = "A" });
            items.Add(new Item() { Name = "Item2", Category = "A" });
            items.Add(new Item() { Name = "Item3", Category = "A" });
            items.Add(new Item() { Name = "Item4", Category = "B" });
            items.Add(new Item() { Name = "Item5", Category = "B" });
            var queryable = items.AsQueryable();
 
          var  ocAccounts = new ObservableCollection<Item>(queryable);
       
            ListCollectionView lcv = new ListCollectionView(ocAccounts);
            lcv.GroupDescriptions.Add(new PropertyGroupDescription("Category"));
            this.comboBox.ItemsSource = lcv;
