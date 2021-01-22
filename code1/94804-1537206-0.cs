    protected void Page_Load(object sender, EventArgs e) {            
        string id = "";
        foreach (string key in Request.Params.AllKeys) {
            if (!String.IsNullOrEmpty(Request.Params[key]) && Request.Params[key].Equals("Click"))
                id = key;
        }
        if (!String.IsNullOrEmpty(id)) {
            Control myControl = FindControl(id);
            // Some code with myControl
        }
    }
