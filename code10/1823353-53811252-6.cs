    public abstract class Item {
      public string ItemName { get; set; }
      public string Cost { get; set; }
      public Item() {
        ItemName = "";
      }
      public Item(string itemName, string cost) {
        ItemName = itemName;
        Cost = cost;
      }
      public void SetPanelLabels(Panel panel) {
        Label lbl = new Label();
        lbl.AutoSize = true;
        lbl.Text = "Item Name: " + ItemName + "   Cost: " + Cost;
        lbl.Location = new System.Drawing.Point(10, 10);
        panel.Controls.Add(lbl);
        SetItemPropertiesLabels(panel);
      }
      // This is the method that all inheritors must implement.
      public abstract void SetItemPropertiesLabels(Panel panel);
    }
