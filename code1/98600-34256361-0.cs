    private static string getComputerDomain()
            {
                try
                {
                    return Domain.GetComputerDomain().Name;
                }
                catch (ActiveDirectoryObjectNotFoundException)
                {
                    return "Local (No domain)";
                }
            }
