    HtmlForm form;
            foreach (var ctl in Page.Controls[0].Controls) { 
                if (ctl is HtmlForm) { 
                    form = ctl as HtmlForm; 
                    ContentPlaceHolder holder = form.FindControl("DefaultContent") as ContentPlaceHolder; 
                    if (holder != null) {
                        RadioButtonList rblControlHolder = holder.FindControl("rblActionLevel") as RadioButtonList; 
                        if (rblControlHolder != null) {
                            if (rblControlHolder.SelectedValue == "Base") {
                            }
                        }
                    }
                }
            }
