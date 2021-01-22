    public void AddDocument(HttpPostedFileBase file)
            {
                try
                {                
                        using (TransactionScope scope = new TransactionScope())
                        {
                            try
                            {
                                using (var ctx = new Entities())
                                {
                                
                                EntityDoc doc = new EntityDoc(); //The document table 
                                
                                doc.DocumentFileName = file.FileName; //The file Name
    
                                using (var reader = new System.IO.BinaryReader(file.InputStream))
                                {
                                    doc.DocumentFile = reader.ReadBytes(file.ContentLength); // the Byte [] Field
                                }
                                ctx.EntityDocs.Add(doc);
                                    
    
                                    ctx.SaveChanges();
                                    scope.Complete();
                                }
                            }
                            catch (Exception ex)
                            {                          
                                throw ex;
                            }
                        }
                   
                }
                catch (Exception ex)
                {
                    
                    throw ex;
                }
            }
