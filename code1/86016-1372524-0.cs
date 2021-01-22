    protected void Page_Load(object sender, EventArgs e)
    {
        foreach (Control control in Controls)
        {
            DisableEvent(control);
        }
    }
    protected void Page_PreRender(object sender, EventArgs e)
    {
        foreach (Control control in Controls)
        {
            UpdateViewstate(control);
        }
    }
    private void DisableEvent(Control current)
    {
        foreach (Control control in current.Controls)
        {
            if (control.GetType() == typeof(Button))
            {
                if (IsPostBack)
                {
                    if (Session["update" + control.ID].ToString() != ViewState["update" + control.ID].ToString())
                    {
                        RemoveClickEvent((Button)control);
                    }
                    else
                    {
                        ((Button)control).Click += new EventHandler(Button_Disable);
                    }
                }
                else
                {
                    Session["update" + control.ID] = Server.UrlEncode(System.DateTime.Now.ToString());
                }
            }
            DisableEvent(control);
        }
    }
    private void UpdateViewstate(Control current)
    {
        foreach (Control control in current.Controls)
        {
            if (control.GetType() == typeof(Button))
            {
                ViewState["update" + control.ID] = Session["update" + control.ID];
            }
            UpdateViewstate(control);
        }
    }
    void RemoveClickEvent(Button b) {
        System.Reflection.FieldInfo f1 = typeof(Button).GetField("EventClick", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic); 
        object obj = f1.GetValue(b);
        System.Reflection.PropertyInfo pi = typeof(Button).GetProperty("Events", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        System.ComponentModel.EventHandlerList list = (System.ComponentModel.EventHandlerList)pi.GetValue(b, null); 
        list.RemoveHandler(obj, list[obj]); 
    }
    protected void Button_Disable(object sender, EventArgs e)
    {
        Button b = (Button)sender;
        Session["update" + b.ID] = Server.UrlEncode(System.DateTime.Now.ToString());
    }
