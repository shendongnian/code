    List<WebControl> wcBasics = new List<WebControl>();
    wcBasics.Add(ddlTranscriptionMethod);
    wcBasics.Add(ddlSpeechRecognition);
    wcBasics.Add(ddlESignature);
    List<CheckBox> checks = new List<CheckBox>();
    checks.Add(chkViaFax);
    checks.Add(chkViaInterface);
    checks.Add(chkViaPrint);
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
        chkViaSelfService.Focus();
    }
