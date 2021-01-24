    protected override void PrepareLayout()
    {
        StartLayout();
        Append("<div");
        Append(" style=\"width: ", "100%", "\"");
        if (IsDesign)
        {
            Append(" id=\"", ShortClientID, "_env\">");
            Append("<table class=\"LayoutTable\" cellspacing=\"0\" style=\"width: 100%;\">");
            if (ViewModeIsDesign())
            {
                Append("<tr><td class=\"LayoutHeader\" colspan=\"2\">");
                // Add header container
                AddHeaderContainer();
                Append("</td></tr>");
            }
            Append("<tr><td id=\"", ShortClientID, "_info\" style=\"width: 100%;\">");
        }
        else
        {
            Append(">");
        }
        // Add the tabs
        var acc = new CMSAccordion();
        acc.ID = ID + "acc";
        AddControl(acc);
        if (IsDesign)
        {
            Append("</td>");
            if (AllowDesignMode)
            {
                // Width resizer
                Append("<td class=\"HorizontalResizer\" onmousedown=\"" + GetHorizontalResizerScript("env", "Width", false, "info") + " return false;\">&nbsp;</td>");
            }
            Append("</tr>");
        }
        // Pane headers
        string[] headers = TextHelper.EnsureLineEndings("HEADER", "\n").Split('\n');
        // Create new pane
        var pane = new CMSAccordionPane();
        pane.ID = ID + "pane";
        pane.Header = new TextTransformationTemplate(string.Empty);
        acc.Panes.Add(pane);
        pane.WebPartZone = AddZone(ID + "-ContentArea", ID + "-ContentArea", pane.ContentContainer);
        acc.SelectedIndex = 1;
        if (IsDesign)
        {
            if (AllowDesignMode)
            {
                Append("<tr><td class=\"LayoutFooter cms-bootstrap\" colspan=\"2\"><div class=\"LayoutFooterContent\">");
                // Pane actions
                Append("<div class=\"LayoutLeftActions\">");
                Append("</div></div></td></tr>");
            }
            Append("</table>");
        }
        Append("</div>");
        FinishLayout();
    }
