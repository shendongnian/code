           try
            {
                if (!string.IsNullOrWhiteSpace(TargetCtrlID))
                {
                    var ctrl = NamingContainer.FindControl(TargetCtrlID);
                    if(ctrl != null)
                        Console.Write("'" + ctrl.ClientID + "'");
                }
            }
            catch
            {
                     
            }
