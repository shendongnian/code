    protected void Process_Command(object sender, CommandEventArgs e)
            {
                if (Session["Status"] != "Refreshed")
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(e.CommandArgument)))
                    {
    
                        using (var transaction = context.Database.BeginTransaction())
                        {
                            DocumentOGP objDocumentOGP = context.DocumentOGPs.Find(Convert.ToInt64(e.CommandArgument));
    
                            objDocumentOGP.UpdationDate = DateTime.Now;
                            objDocumentOGP.DispatchStatusID = 2;
                            context.DocumentOGPs.Add(objDocumentOGP);
                            context.Entry(objDocumentOGP).State = System.Data.Entity.EntityState.Modified;
                            context.SaveChanges();
                            transaction.Commit();
                            FillGrid();
                            Session["OGPCode"] = Convert.ToString(e.CommandArgument);
    
                        }
                   
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "OpenWindow", "window.open('http://localhost:56430/DownLoadExcel','_newtab');", true);
                    }
                }
            } 
