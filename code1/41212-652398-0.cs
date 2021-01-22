            // Get the type of the Windows Installer object
            Type installerType = Type.GetTypeFromProgID("WindowsInstaller.Installer");
            // Create the Windows Installer object
            Installer installer = (Installer)Activator.CreateInstance(installerType);
            // Open the MSI database in the input file
            Database database = installer.OpenDatabase(inputFile, MsiOpenDatabaseMode.msiOpenDatabaseModeReadOnly);
            // Open a view on the Property table for the version property
            View view = database.OpenView("SELECT * FROM Property WHERE Property = 'ProductVersion'");
            // Execute the view query
            view.Execute(null);
            // Get the record from the view
            Record record = view.Fetch();
            // Get the version from the data
            string version = record.get_StringData(2);
