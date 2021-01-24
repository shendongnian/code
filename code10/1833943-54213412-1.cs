     using (Service_HR_Person srvPerson = Bootstrapper.Container.Resolve<Service_HR_Person>())
                    {
                        srvPerson.Delete(base.rowid);
                        try
                        {
                            srvPerson.Save();
                            RemoveRow();
                            MessageManager.Show(Enums.MessageBoxType.InformationTransactionSuccessfully);
                        }
                        catch (Exception ex)
                        {
                            MessageManager.Show(ErrorManager.ProccessException(ex), Enums.MessageBoxType.Error);
                        }
                    }
