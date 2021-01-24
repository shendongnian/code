            //Add data
            IUList list1 = new IUList("1", "1", "1", "1");
            IUList list11 = new IUList("11", "1", "1", "1");
            IUList list111 = new IUList("1111", "1", "1", "1");
            IUList list1111 = new IUList("11111", "1", "1", "1");
            ObservableCollection<IUList> ius = new ObservableCollection<IUList>();
            ius.Add(list1); ius.Add(list11); ius.Add(list111); ius.Add(list1111);
            //Bind source
            comboBox.ItemsSource = ius;
