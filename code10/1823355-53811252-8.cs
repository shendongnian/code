    class Shield : Item {
      public string Defense { get; set; }
      public string Material { get; set; }
      public Shield(string itemName, string cost) : base(itemName, cost) {
      }
      public override void SetItemPropertiesLabels(Panel panel) {
        Label lbl = new Label();
        lbl.AutoSize = true;
        lbl.Text = "Shield Defense: " + Defense + "  Material: " + Material;
        lbl.Location = new System.Drawing.Point(15, 50);
        panel.Controls.Add(lbl);
      }
    }
