    if(control is TextBox || control is DropDownList || control is RadioButton || control is RadioButtonList 
                    || control is CheckBox || control is CheckBoxList)
                    {
                        if (control is TextBox)
                        {
                            TextBox txt = control as TextBox;
                            if (txt.Text != "" && txt.Text != "YYYY/MM/DD")
                            {
                                setGroup(control);
                                if (isAControl)
                                {
                                    string controlNoGroup = lstControls.Last();
                                    strHtml = strHtml.Replace("@" + (controlNoGroup.ToString()) + "@", txt.Text);
                                }
                            }
                        }
