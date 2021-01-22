    // This is a method of a Form with one of these:
    //     CrystalDecisions.Windows.Forms.CrystalReportViewer
    // This hides the tab control with the "Main Report" button.
    public void hideTheTabControl()
    {
        System.Diagnostics.Debug.Assert(
            crystalReportViewer1.ReportSource != null, 
            "you have to set the ReportSource first");
        foreach (Control c1 in crystalReportViewer1.Controls)
        {
            if (c1 is CrystalDecisions.Windows.Forms.PageView)
            {
                PageView pv = (PageView)c1;
                foreach (Control c2 in pv.Controls)
                {
                    if (c2 is TabControl)
                    {
                        TabControl tc = (TabControl)c2;
                        tc.ItemSize = new Size(0, 1);
                        tc.SizeMode = TabSizeMode.Fixed;
                    }
                }
            }
        }
    }
