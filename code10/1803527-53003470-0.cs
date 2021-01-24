    public void CreateSlide(string name, string title, string desc) {
      var PanelOrder = new Panel() { 
        Name = name,
        Size = new Size(395, 33),
        BorderStyle = BorderStyle.FixedSingle,
        Location = new Point(203, 157),
        Parent = this // <- Put PanelOrder panel on the form
      };
    
      var ckOrder = new CheckBox() {
        Name = name,
        Text = "Order",
        Size = new Size(102, 21),
        Location = new Point(3, 5),
        FlatStyle = FlatStyle.Flat,
        Font = new Font("Segoe UI", 10, FontStyle.Bold),
        Parent = PanelOrder // <- Put ckOrder on the PanelOrder panel
      };
    
      var TxtQty = new TextBox() {
        Name = name,
        Text = "1",
        Visible = false,
        BorderStyle = BorderStyle.FixedSingle,
        Size = new Size(100, 25),
        Location = new Point(290, 3),
        Parent = PanelOrder // <- Put TxtQty on the PanelOrder panel
      };
    
      // lambda function
      ckOrder.CheckedChanged += (s, e) => {
        TxtQty.Visible = ckOrder.Checked;
      };
    }
