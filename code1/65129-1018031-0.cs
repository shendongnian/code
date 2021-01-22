    private delegate void addControlToPanelDelegate(string picname, string thumburl, PicasaEntry entry, Int32 top, EventHandler clickevent);
    private void addControlToPanel(string picname, string thumburl, PicasaEntry entry, Int32 Ordinal,EventHandler clickevent)
    {
        if (panel1.InvokeRequired)
        {
            addControlToPanelDelegate d = new addControlToPanelDelegate(addControlToPanel);
            this.Invoke(d, new object[] { picname, thumburl, entry, Ordinal, clickevent });
            //panel1.Invoke(d, new object[] { li });
        }
        else
        {
            ListItem li = new ListItem(picname, thumburl, entry);
            li.Top = Ordinal * li.Height;
            li.Click += clickevent;
            panel1.Controls.Add( li);
        }
    }
