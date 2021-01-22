    ObservableCollection<int> myList = new ObservableCollection<int>();
    myList.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(
        delegate(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)                    
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                MessageBox.Show("Added value");
            }
        }
    );
    myList.Add(1);
