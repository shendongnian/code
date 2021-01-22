    List<WebControl> wcBasics = new List<WebControl>();
    wcBasics.Add(ddlOne);
    wcBasics.Add(TextBox1);
    wcBasics.Add(ddlTwo);
    List<CheckBox> checks = new List<CheckBox>();
    checks.Add(chkThree);
    checks.Add(chkTwo);
    checks.Add(chkFour);
    checks.Add(chkOne);
    private void Focus()
    {
        foreach (WebControl c in wcBasics)
            if (c.Visible) {
                c.Focus();
                return;
            }
        if (!tblDistributionMethods.Visible) return;
        foreach (CheckBox chk in checks)
            if (chk.Visible) {
                chk.Focus();
                return;
            }
        }
    }
