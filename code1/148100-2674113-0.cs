    ListView.SelectedIndexCollection indexes = this.ListView1.SelectedIndices;
    double price = 0.0;
    foreach ( int index in indexes )
    {
      price += Double.Parse(this.ListView1.Items[index].SubItems[1].Text);
    }
