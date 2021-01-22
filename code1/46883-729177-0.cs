    foreach (Inspection inspection in anInspector.getInspections())
      {
        ListViewItem item = new ListViewItem();
        item.Text=anInspector.getInspectorName().ToString();
        item.SubItems.Add(inspection.getInspectionDate().ToShortDateString());
        item.SubItems.Add(inspection.getHouse().getAddress().ToString());
        item.SubItems.Add(inspection.getHouse().getValue().ToString("C"));
        listView1.Items.Add(item);
      }
