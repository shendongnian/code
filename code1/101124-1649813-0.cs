    private void Copy(ListBox Source, ListBox Target) {
         int[] selectedIndices;
         ListItemCollection licCollection;
         ListBox objTarget;
         try
         {
             selectedIndices = Source.GetSelectedIndices();
             licCollection = new ListItemCollection();
             objTarget = new ListBox();
             if (Target != null && Target.Items.Count > 0)
             {
                 foreach (ListItem item in Target.Items)
                 {
                     objTarget.Items.Add(item);
                 }
                 Target.Items.Clear();
             }
             int selectedIndexLength = selectedIndices.Length;
             for (int intCount = 0; intCount < selectedIndexLength; intCount++)
             {
                 licCollection.Add(Source.Items[selectedIndices[intCount]]);
             }
             int collectionCount = licCollection.Count;
             for (int intCount = 0; intCount < collectionCount; intCount++)
             {
                 Source.Items.Remove(licCollection[intCount]);
                 if (!objTarget.Items.Contains(licCollection[intCount]))
                     objTarget.Items.Add(licCollection[intCount]);
             }
