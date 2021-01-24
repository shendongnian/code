    private async void StatesList_KeyUp(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if (!(e.Key >= Windows.System.VirtualKey.A && e.Key <= Windows.System.VirtualKey.Z))
                return;
            string searchLetter = e.Key.ToString();
            ObservableCollection<Type> Names = (ObservableCollection<Type>)List.ItemsSource;
            Type thingToFind;
            if (List.SelectedItem == null)
            {
                thingToFind = Names.Where(x => x.Name.StartsWith(searchLetter)).FirstOrDefault();
            }
            else
            {
                string CurrentName = ((Type)List.SelectedItem).Name;
                var laterItems = Names.Where(x => x.Name.CompareTo(CurrentName) > 0).ToList();
                thingToFind = laterItems.Where(x => x.Name.StartsWith(searchLetter)).FirstOrDefault();
            }
            List.SelectedItem = thingToFind;
            if (thingToFind == null)
                return;
            List.ScrollIntoView(thingToFind);
       }
