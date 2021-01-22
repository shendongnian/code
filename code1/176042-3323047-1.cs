    public void GetDocuments(int dID)
        {           
                _Context = new appDomainContext();  //ADDED THIS LINE TO FIX MY ISSUE                              
                _Context.Load(_Context.GetDocumentsQuery(dID), dlo =>
                    {
                        DocumentsView = dlo.Entities;                                                
                    }, null);                                
            }
        }
