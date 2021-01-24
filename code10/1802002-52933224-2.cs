    private void getRulesBtn_Click(object sender, EventArgs e)
    {
        Type typeFWPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
        INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(typeFWPolicy2);
        foreach (INetFwRule rule in fwPolicy2.Rules)
        {
            ListViewItem item = new ListViewItem(rule.Name, 0);
            // There are other members, just using these as an example
            item.SubItems.Add(rule.RemoteAddresses);
            item.SubItems.Add(rule.Description);
            item.Tag = rule;    // Save for later retrieval
            listView1.Items.Add(item);
        }
    }
