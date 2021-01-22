    DirectoryEntry sited = new DirectoryEntry(string.Format("IIS://localhost/w3svc/{0}/Root", websiteID.ToString()));
    sited.Properties["AccessRead"].Add(true);
            
    PropertyValueCollection testScriptMap = sited.Properties["ScriptMaps"];
            
    object[] allValues = (object[])testScriptMap.Value;
    object[] newValues = new object[allValues.Length];
    string oldVersion = "v1.1.4322";
    string newVersion = "v2.0.50727";
    for (int i = 0; i < allValues.Length; i++)
    {
        if (allValues[i] is string)
        {
            string temp = allValues[i] as string;
            if (temp.Contains(oldVersion))
            {
                newValues[i] = temp.Replace(oldVersion, newVersion);
            }
            else
            {
                newValues[i] = allValues[i];
            }
        }
        else
        {
            newValues[i] = allValues[i];
        }
    }
    testScriptMap.Value = newValues;            
         
    sited.CommitChanges();
