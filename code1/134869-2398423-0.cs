    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ListView lv = (ListView)sender;
        if (lv.SelectedIndices.Count == 0)
        {
            if (!this.appIdleEventScheduled)
            {
                this.appIdleEventScheduled = true;
                this.listViewToMunge = lv;
                Application.Idle += new EventHandler(Application_Idle);
            }
        }
        else
            this.lastSelectedIndex = lv.SelectedIndices[0];
    }
    
    void Application_Idle(object sender, EventArgs e)
    {
        Application.Idle -= new EventHandler(Application_Idle);
        this.appIdleEventScheduled = false;
        if (listViewToMunge.SelectedIndices.Count == 0) 
            listViewToMunge.SelectedIndices.Add(this.lastSelectedIndex);
    }
    
    private bool appIdleEventScheduled = false;
    private int lastSelectedIndex = -1;
    private ListView listViewToMunge;
