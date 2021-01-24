    private string getCommandNames()
            {
                StringBuilder commandNamesFound = new StringBuilder();
                String delimiter = Environment.NewLine;
                foreach (CrystalDecisions.CrystalReports.Engine.Table table in rptDoc.Database.Tables)
                {
                    commandNamesFound.Append(table.Name);
                    commandNamesFound.Append(delimiter);
                }
    
                return commandNamesFound.ToString();
            }
