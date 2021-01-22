    DataGridViewLinkColumn links = new DataGridViewLinkColumn();
    links.UseColumnTextForLinkValue = true;
    links.HeaderText = "Links"; //put the header text you want here
    links.DataPropertyName = "webSite"; //This is from your query
    links.ActiveLinkColor = Color.White;
    links.LinkBehavior = LinkBehavior.SystemDefault;
    links.LinkColor = Color.Blue;
    links.TrackVisitedState = true;
    links.VisitedLinkColor = Color.YellowGreen;
    grdHashamaLst.Columns.Add(links);
