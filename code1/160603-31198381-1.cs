    udsShowUDFields("Mail Status", mailitem);
    
                public void udsShowUDFields(string sFldName, OutLook.MailItem mailItem)
                {
                    
                    var _with1 = oOlApp.ActiveExplorer().CurrentView as OutLook.TableView;
                    try
                    {
        
                        if (_with1.ViewType == OutLook.OlViewType.olTableView)
                        {
                            _with1.ViewFields.Add(sFldName);
                            _with1.Apply();
                        }
                    }
                    catch (Exception ex)
                    {
                        _with1.Apply();
                    }
                }
