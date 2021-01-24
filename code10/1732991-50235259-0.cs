                     using (ClientContext ctx = new ClientContext(searchsiteurl))
                    {
                        //NetworkCredential credit = new NetworkCredential(prg.userName, prg.password, prg.domain);
                        //ctx.Credentials = credit;
                        Web web = ctx.Web;
                        
                        List list = web.Lists.GetById(new Guid(site.ListGUID));
 
                       var q = new CamlQuery();
                        if (Fullsync)
                        {
                            q.ViewXml = "<View><Query><Where><And><BeginsWith><FieldRef Name='SrNumber' /><Value Type='Text'>1</Value></BeginsWith>" +
                                "<Eq><FieldRef Name='_ModerationStatus' /><Value Type='ModStat'>Draft</Value></Eq></And></Where></Query></View>";
                        }
                        else
                        {
                            q.ViewXml = "<View><Query><Where><And><Contains><FieldRef Name='SrNumber' /><Value Type='Text'>1-</Value></Contains><And>" +
                                    "<Eq><FieldRef Name='_ModerationStatus' /><Value Type='ModStat'>Approved</Value></Eq>" +
                                    "<Gt><FieldRef Name='Modified' /><Value IncludeTimeValue='TRUE' Type='DateTime'>" + last24hours + "</Value></Gt>" +
                                    "</And></And></Where></Query></View>";
                        }
                        var r = list.GetItems(q);
                        ctx.Load(r);
                        ctx.ExecuteQuery();
						foreach (SP.ListItem lit in r)
                        {
                                    //do a whole bunch of stuff....
                                    /* this does NOT WORK
                                    lit.FieldValues["Linked_x0020_CSRs"] = LinkedSRs;
                                    lit.Update();
                                    ctx.ExecuteQuery();
                                    */
                                    
                                    // this works!
                                        var KAToModify = list.GetItemById(lit.Id);
                                        KAToModify["Linked_x0020_CSRs"] = LinkedSRs;
                                        KAToModify.Update();
                                        ctx.ExecuteQuery();
                        }
				}
