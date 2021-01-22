    protected void Page_Load(object sender, EventArgs e)
    {
        for (int i = 0; i < Controls.Count; i++)
            if (Controls[i] is myLastContol)
                while (i + 2 < Controls.Count)
                {
                    plhContent.Controls.Add(Controls[i + 2]);
                } 
        base.OnPreRender(e);
    }
