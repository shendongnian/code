    CheckBoxList clicked = (CheckBoxList)sender;
        bool selected = clicked.Items.FindByValue("33").Selected;
        if (selected)
        {
            if (Convert.ToBoolean(ViewState["Clicked"]) == false)
            {
                //do something
                ViewState["Clicked"] = true;
            }
        }
        else
        {
            ViewState["Clicked"] = false;
        }
