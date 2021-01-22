    public void DisableForm(ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Enabled = false;
                else if (ctrl is DropDownList)
                    ((DropDownList)ctrl).Enabled = false;
                else if (ctrl is HtmlInputText)
                    ((HtmlInputText)ctrl).Disabled = true;
                else if (ctrl is HtmlSelect)
                    ((HtmlSelect)ctrl).Disabled = true;
                DisableForm(ctrl.Controls);
            }
        }
