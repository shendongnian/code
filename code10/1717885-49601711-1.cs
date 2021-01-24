    private void TVShowPanel_Load(object sender, EventArgs e)
    {
        Bunifu.Framework.UI.BunifuThinButton2 dd = new Bunifu.Framework.UI.BunifuThinButton2
        {
            Tag = ll[0].episodeTitle + "\n" + ll[0].episodeOverview,
            Size = new Size(40, 40),
            TextAlign = ContentAlignment.MiddleCenter,
        }
        tooltip1.SetToolTip(dd, dd.Tag.ToString());
    }
