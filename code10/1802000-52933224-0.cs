    private void getRulesBtn_Click(object sender, EventArgs e)
    {
        Type typeFWPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
        INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(typeFWPolicy2);
        foreach (INetFwRule rule in fwPolicy2.Rules)
        {
            int index = listBox1.Items.Add(rule.Name);
        }
    }
