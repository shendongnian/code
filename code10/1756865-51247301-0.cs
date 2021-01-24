    String ErrorMessages = String.Empty;
    
    if (resultCollection.ContainsErrors) {
                    ErrorMessages += $"Errors occured in cube {ConnectionString.CatalogName}:" + Environment.NewLine;
                    foreach (AS.XmlaResult result in resultCol) {
                        foreach (object error in result.Messages) {
                            if (error.GetType() == typeof(AS.XmlaError))
                                ErrorMessages += "ERR: " + ((AS.XmlaError)error).Description + Environment.NewLine;
                            else if (error.GetType() == typeof(AS.XmlaWarning))
                                ErrorMessages += "WARN: " + ((AS.XmlaWarning)error).Description + Environment.NewLine;
                        }
                    }
                    throw new Exception(ErrorMessages);
                }
