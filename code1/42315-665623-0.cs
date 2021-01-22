    public static string SetConnectionString(Type assemblyMember,
                                             Type settingsClass,
                                             string newConnectionString,
                                             string connectionStringKey)
    {
      Type typSettings = Type.GetType(Assembly.CreateQualifiedName(assemblyMember.Assembly.FullName, settingsClass.FullName));
      if (typSettings == null)
      {
        return null;
      }
      PropertyInfo prpDefault = typSettings.GetProperty("Default", BindingFlags.Static | BindingFlags.Public);
      if (prpDefault == null)
      {
        return null;
      }
      object objSettings = prpDefault.GetValue(null, null);
      if (objSettings == null)
      {
        return null;
      }
      // the default property, this[], is actually named Item
      PropertyInfo prpItem = objSettings.GetType().GetProperty("Item", BindingFlags.Instance | BindingFlags.Public);
      if (prpItem == null)
      {
        return null;
      }
      object[] indexerName = { connectionStringKey };
      string oldConnectionString = (string)prpItem.GetValue(objSettings, indexerName);
      prpItem.SetValue(objSettings, newConnectionString, indexerName);
      return oldConnectionString;
    }
