    if (!Page.IsPostBack)
        {
            Session["currentLang"] = "ar";
            ChangeLang("ar");
        }
        else
        {
            GISServiceReference.GISServiceClient gisservice = new GISServiceReference.GISServiceClient();
            List<GISServiceReference.LandMarkClass> result = gisservice.GetConsData(Session["currentLang"].ToString(), Session["catName"].ToString()).ToList();
            tabContentRepeater.DataSource = result;
            tabContentRepeater.DataBind();
            ScriptManager.RegisterClientScriptBlock(this, typeof(System.Web.UI.Page), "checkDir", "checkDir();", true);
            UpdatePanel2.Update();
        }
