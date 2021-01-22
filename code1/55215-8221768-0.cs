    public void registerUCAsyncPostBack(Page page, WebControl webcontrol, UserControl usercontrol){
                Control ControlAjaxNew = null;
                if (webcontrol.GetType() == typeof(LinkButton))
                {
                    ControlAjaxNew = (LinkButton)usercontrol.FindControl(webcontrol.ID);
                }
                ScriptManager.GetCurrent(page).RegisterAsyncPostBackControl(ControlAjaxNew);
            }
