    using (SPSite site = new SPSite("Yoursitename"))
            {
                using (SPWeb web = site.OpenWeb())
                {
                    SPList list = web.Lists.TryGetList("HyperLink");
                    if (list != null)
                    {
                        SPListItem item = list.Items.Add();
                        SPFieldUrlValue hyper = new SPFieldUrlValue();
                        hyper.Description = "Stack overflow";
                        hyper.Url = "http://www.stackoverflow.com";
                        item["Title"] = "New item";
                        item["Hyper"] = hyper;
                        item.Update();                       
                    }
                }
            }
