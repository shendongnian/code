    SPGroupCollection collGroups = SPContext.Current.Web.Groups;
                   
     foreach (SPGroup oGroup in collGroups)
                    {
                        foreach (SPUser oUser in oGroup.Users)
                        {
                            Response.Write(oUser.Name);
    
                        Label l = new Label();
                        l.Text = oUser.Name;
    
                        PlaceHolderContents.Controls.Add(l);
                        PlaceHolderContents.Controls.Add(new LiteralControl("<br/>"));
                    }
                }
