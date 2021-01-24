    var model = new RootObject();
                model.item = new Item
                {
                    attrs = new Attrs
                    {
                        attr = new List<Attr>
                    {
                        new Attr { name = "IP_Category", value = ddlContent.Text },
                        new Attr { name = "Description", value = txtDesc.Text },
                        new Attr { name = "Title", value = txtTitle.Text }
                    }
                    },
                    resrs = new Resrs
                    {
                        res = new List<Re>
                    {
                        new Re { filename = fName, base64 = base64string},
                    }
                    },
                    acl = new Acl
                    {
                        name = "Submitter"
                    },
                    entityName = "IP_Document"
                };
