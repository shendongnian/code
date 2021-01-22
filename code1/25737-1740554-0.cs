    public string ImportMarriageXML(bool isWakeUp, bool clearExistingMarriage)
    {
        try
        {
            var dts = new Microsoft.SqlServer.Dts.Runtime.Application();
            using (var package = dts.LoadFromSqlServer(
                ServiceSettings.Settings.SSIS.ImportMarriages,
                ServiceSettings.Settings.SSIS.ServerIP,
                ServiceSettings.Settings.SSIS.UserID,
                ServiceSettings.Settings.SSIS.Password,
                null))
            {
                package.InteractiveMode = false;
                package.Connections["DB.STAGING"].ConnectionString = String.Format("{0};Provider={1};", DBSettings.ConnectionString(Core.Database.Staging), ServiceSettings.Settings.SSIS.Provider);
                var variables = package.Variables;
                variables["IsWakeUp"].Value = isWakeUp;
                variables["ClearExistingMarriage"].Value = clearExistingMarriage;
                variables["XmlDirectory"].Value = ServiceSettings.Settings.SSIS.Properties.XmlDirectory;
                if (package.Execute() == DTSExecResult.Failure)
                {
                    // HACK: Need to refactor this at some point. Will do for now.
                    var errors = new System.Text.StringBuilder();
                    foreach (var error in package.Errors)
                        errors.AppendFormat("SubComponent: {0}; Description: {1}{2}", error.SubComponent, error.Description, Environment.NewLine);
                    throw new ApplicationException(errors.ToString());
                }
                return package.Connections["Text Logging"].ConnectionString;
            }
        }
    }
