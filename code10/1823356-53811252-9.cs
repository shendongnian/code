    class Weapon : Item {
      public string Attack { get; set; }
      public string Type { get; set; }
      public Weapon() {
      }
      public Weapon(string itemName, string cost) : base(itemName, cost) {
      }
      public override void SetItemPropertiesLabels(Panel panel) {
        Label lbl = new Label();
        lbl.AutoSize = true;
        lbl.Text = "Weapon Type: " + Type + "  Attack: " + Attack;
        lbl.Location = new System.Drawing.Point(15, 50);
        panel.Controls.Add(lbl);
      }
    }
