    foreach (Control panelctrl in UpdatePanel1.ContentTemplateContainer.Controls)
    {
        if (panelctrl is Panel)
        {
            Panel p = (Panel)panelctrl;
            foreach (Control txt in p.Controls)
            {
                if (txt is TextBox)
                {
                    TextBox txtBox = (TextBox)txt;
                    // do something with textbox
                }
            }
        }
    }
