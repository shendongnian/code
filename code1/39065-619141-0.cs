    class SomeView 
    {
      void SetData(IEnumerable<DataItem> dataItems) 
      {
        foreach(DataItem dataItem in dataItems) 
        {
          ListViewItem lvi = new ListViewItem();
          lvi.Text = dataItem.Text;
          ...
        }
      }
    }
