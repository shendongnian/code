    protected override void CreateChildControls()
    {
        base.CreateChildControls();
        Panel around = new Panel();
        Panel myPanel = new Panel();
        myPanel.ID = "SelectionPanel";
        around.Controls.Add(myPanel);
        // ... other controls ... \\
        this.Controls.Add(around);
    }
