                catch (Exception ex)
                {
                   
                    switch (ex.GetType().Name)
                    {
                        case "System.FormatException":
                        case "System.OverflowException":
                            WebId = Guid.Empty;
                            break;
                        default:
                            throw;                           
                    }
                }
