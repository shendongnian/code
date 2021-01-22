    using System.IO
    using System.Diagnostics;
    public static void SaveACopyfileToServer(string filePath, string savePath)
        {
            var directory = Path.GetDirectoryName(savePath).Trim();
            var username = "loginusername";
            var password = "loginpassword";
            var filenameToSave = Path.GetFileName(savePath);
            if (!directory.EndsWith("\\"))
                filenameToSave = "\\" + filenameToSave;
            var command = "NET USE " + directory + " /delete";
            ExecuteCommand(command, 5000);
            command = "NET USE " + directory + " /user:" + username + " " + password;
            ExecuteCommand(command, 5000);
            command = " copy \"" + filePath + "\"  \"" + directory + filenameToSave + "\"";
            
            ExecuteCommand(command, 5000);
            command = "NET USE " + directory + " /delete";
            ExecuteCommand(command, 5000);
        }
