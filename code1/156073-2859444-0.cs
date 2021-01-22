        Dictionary<string,string> newlist = new Dictionary<string,string>();
        newlist.Add("opt1","no org" +Session["schubles"]+ "but opt bla");
        newlist.Add("opt2","no org" +Session["schubles"]+ "but opt blo");
        newlist.Add("opt3","no org" +Session["schubles"]+ "but opt blum");
        rlist.DataValueField = "key";
        rlist.DataTextField = "value";
        rlist.DataSource = newlist;
        rlist.DataBind();
