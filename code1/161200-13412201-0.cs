    using (ClientContext context = new ClientContext("http://spsite2010"))
                    {
                        context.Credentials = new NetworkCredential("admin", "password");
                        Web oWeb = context.Web;
                        List list = context.Web.Lists.GetByTitle("Tasks");
                        CamlQuery query = new CamlQuery();
                        query.ViewXml = "<View><Where><Eq><FieldRef Name = \"Title\"/><Value Type=\"String\">New Task Created</Value></Eq></Where></View>";
                        ListItemCollection listItems = list.GetItems(query);
                        context.Load(listItems);
                        context.ExecuteQuery();
                        FileStream oFileStream = new FileStream(@"C:\\sample.txt", FileMode.Open);
                        string attachmentpath = "/Lists/Tasks/Attachments/" + listItems[listItems.Count - 1].Id + "/sample.txt";
                        Microsoft.SharePoint.Client.File.SaveBinaryDirect(context, attachmentpath, oFileStream, true);
                    }
