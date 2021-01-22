    protected override void  OnPreRender(EventArgs e)
    {
        for (int i = 0; i < Controls.Count; i++)
            if (Controls[i] is myLastContol)
                do
                {
                    plhContent.Controls.Add(Controls[i + 2]);
                } while (i + 2 < Controls.Count);
        base.OnPreRender(e);
    }
