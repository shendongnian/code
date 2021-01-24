    var itemsInGroup1 = new ObservableCollection<MoveableItem>()
            {
                new MoveableItem {ID = 1, Name = "Item 1"},
                new MoveableItem {ID = 2, Name = "Item 2"},
                new MoveableItem {ID = 3, Name = "Item 3"},
            };
            var itemsInGroup2 = new ObservableCollection<MoveableItem>()
            {
                new MoveableItem {ID = 4, Name = "Item 4"},
                new MoveableItem {ID = 5, Name = "Item 5"},
                new MoveableItem {ID = 6, Name = "Item 6"},
            };
            List1.ItemsSource = itemsInGroup1;
            List2.ItemsSource = itemsInGroup2;
