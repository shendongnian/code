      if (Context.User != null)
                    {
                        ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
                    }
                    else {
                        ViewState[AntiXsrfUserNameKey] = String.Empty;
                    }
