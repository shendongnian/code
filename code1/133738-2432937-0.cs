    using System;
    using COMAdmin;
    using Microsoft.VisualBasic;
    
    namespace TesteAdicionaRole
    {
        class Program
        {
            static void Main(string[] args)
            {
                string packageName = "TRICOLOR";
                ICOMAdminCatalog catalog = (ICOMAdminCatalog)Interaction.CreateObject("COMAdmin.COMAdminCatalog", string.Empty);
                ICatalogCollection packages = (ICatalogCollection)catalog.GetCollection("Applications");
    			packages.Populate();
                foreach (ICatalogObject package in packages)
                    if (package.Name.ToString().Equals(packageName))
                    {
                        ICatalogCollection roles = (ICatalogCollection)packages.GetCollection("Roles", package.Key);
                        roles.Populate();
                        ICatalogObject role = (ICatalogObject)roles.Add();
                        role.set_Value("Name", "MyRoleName");
                        roles.SaveChanges();
                        ICatalogCollection users = (ICatalogCollection)roles.GetCollection("UsersInRole", role.Key);
                        users.Populate();
                        ICatalogObject user = (ICatalogObject)users.Add();
                        user.set_Value("User", "MV0266\\IUSR_MV0266");
                        users.SaveChanges();
                        break;
                    }            
            }
        }
    }
