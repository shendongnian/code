    void OnSelection (object sender, SelectedItemChangedEventArgs e)
    {
      if (e.SelectedItem == null) {
        return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
      }
      DisplayAlert ("Item Selected", e.SelectedItem.ToString (), "Ok");
      //((ListView)sender).SelectedItem = null; //uncomment line if you want to disable the visual selection state.
    }
