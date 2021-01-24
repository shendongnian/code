                if (c is CheckBox && c.Name.StartsWith("metroCheck"))
                {
                    ((CheckBox)c).CheckState = CheckState.Checked;
                }
                else if (c.HasChildren)
                {
                    foreach (Control cc in c.Controls)
                    {
                        if (cc is CheckBox && cc.Name.StartsWith("metroCheck"))
                        {
                            ((CheckBox)cc).CheckState = CheckState.Checked;
                        }
                    }
                }
