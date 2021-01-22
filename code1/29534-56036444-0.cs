            try
            {
                //Variablen für die Verarbeitung
                string source_file = @"C:\temp\offer.pdf";
                string web_url = "https://stackoverflow.sharepoint.com";
                string library_name = "Documents";
                string admin_name = "admin@stackoverflow.com";
                string admin_password = "Password";
    
                //Verbindung mit den Login-Daten herstellen
                var sercured_password = new SecureString();
                foreach (var c in admin_password) sercured_password.AppendChar(c);
                SharePointOnlineCredentials credent = new 
                SharePointOnlineCredentials(admin_name, sercured_password);
    
                //Context mit Credentials erstellen
                ClientContext context = new ClientContext(web_url);
                context.Credentials = credent;
                //Bibliothek festlegen
                var library = context.Web.Lists.GetByTitle(library_name);
                //Ausgewählte Datei laden
                FileStream fs = System.IO.File.OpenRead(source_file);
                //Dateinamen aus Pfad ermitteln
                string source_filename = Path.GetFileName(source_file);
                //Datei ins SharePoint-Verzeichnis hochladen
                FileCreationInformation fci = new FileCreationInformation();
                fci.Overwrite = true;
                fci.ContentStream = fs;
                fci.Url = source_filename;
                var file_upload = library.RootFolder.Files.Add(fci);
                //Ausführen
                context.Load(file_upload);
                context.ExecuteQuery();
                
                //Datenübertragen schließen
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler");
                throw;
            }
