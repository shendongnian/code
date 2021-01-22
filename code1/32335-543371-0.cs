    protected override void CreateChildControls()
    {
        for (int i = 0; i < Controls.Count; i++)
            if (Controls[i] is CollapsiblePanelExtender)
                while (i + 2 < Controls.Count)
                {
                    SearchUpdatePanel(Controls[i + 2]);
                    plhContent.Controls.Add(Controls[i + 2]);
                }
        base.CreateChildControls();
    }
