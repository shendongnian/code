    ...
    var com = new ComboBox();
    com.Name = "reportColumn" + (i + 1).ToString();
    g = tableLayoutPanel2.Controls[com.Name] as ComboBox;
    c.Add(g);
    g.SelectedIndexChanged += new EventHandler(ReportWizardStep1ComboboxSelectedIndexchanged);
    tableLayoutPanel2.Controls.Add(com,1,i);}
