    private void DoubleClickAdd(object sender, MouseButtonEventArgs e) {
        if (e.ClickCount == 2) {
            if (DeckList.SelectedItem != null) {
                Card item = DeckList.SelectedItem as Card;
                test.Text = item.CMC;
                DeckList.Items.Add(List.SelectedItem);
            }
        }
    }
