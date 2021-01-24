    // When a button is clicked...
    private void Button_Click(object sender, EventArgs e)
    {
        // Create a PS instance...
        using (PowerShell instance = PowerShell.Create())
        {
            // And using information about my script...
            var scriptPath = "C:\\myScriptFile.ps1";
            var myScript = System.IO.File.ReadAllText(scriptPath);
            instance.AddScript(myScript);
            instance.AddParameter("param1", "The value for param1, which in this case is a string.");
            // Run the script.
            var output = instance.Invoke();
            // If there are any errors, throw them and stop.
            if (instance.Streams.Error.Count > 0)
            {
                throw new System.Exception($"There was an error running the script: {instance.Streams.Error[0]}");
            }
            // Parse the output (which is usually a collection of PSObject items).
            foreach (var item in output)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
