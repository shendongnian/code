    private void Navtocapus_Click(object sender, args)
    {
        if(Campus_Selector.SelectedIndex != -1)//just to make sure an item is selected
        {
            string item = (Campus_Selector.SelectedItem as ComboboxItem).Content as string;
            //use whatever your frame is to navigate to your desired page using value of item.
            frame.Navigate(typeof(YourPageClass));
        }
    }
