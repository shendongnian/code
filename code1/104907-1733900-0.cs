    playListDS rec = new playListDS();
    if(File.Exists(Server.MapPath("~/playlist.xml")))
    {
        rec.ReadXml(Server.MapPath("~/playlist.xml"));
    }
    
    int id = int.Parse(rec.track.Rows[rec.track.Rows.Count - 1][0].ToString()) + 1;
    
    if (ViewState["Filename"] != null && ViewState["Cover"] != null)
    {
        playListDS.trackListRow row = rec.track.AddtrackRow(id.ToString(), "mp3/" +
                                  ViewState["Filename"].ToString(), txtartist.Text,
                                  txtalbum.Text, txttitle.Text,
                                  txtannotation.Text, txtduration.Text, "mp3/cover" +
                                  ViewState["Cover"].ToString(),
                                  txtinfo.Text, txtlink.Text);
    }
