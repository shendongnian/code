    public static void ReOrganise(this FlowLayoutPanel panel)
    {
        var width = 0;
        Control prevChildCtrl = null;
        panel.SuspendLayout();
        //Clear flow breaks
        foreach (Control childCtrl in panel.Controls)
        {
            panel.SetFlowBreak(childCtrl, false);
        }
        foreach (Control childCtrl in panel.Controls)
        {
            width = width + childCtrl.Width;
            if(width > panel.Width && prevChildCtrl != null)
            {
                panel.SetFlowBreak(prevChildCtrl, true);
                width = childCtrl.Width;
            }
            prevChildCtrl = childCtrl;
        }
        panel.ResumeLayout();
    }
