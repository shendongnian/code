    class Armour : Item {
      public string Type { get; set; }
      public string Material { get; set; }
      public Armour() {
      }
      public Armour(string itemName, string cost) : base(itemName, cost) {
      }
      public override void SetItemPropertiesTextBoxes(Panel panel) {
        Label lbl = new Label();
        lbl.AutoSize = true;
        lbl.Text = "Armour Type: " + Type + "  Material: " + Material;
        lbl.Location = new System.Drawing.Point(15, 50);
        panel.Controls.Add(lbl);
      }
    }
