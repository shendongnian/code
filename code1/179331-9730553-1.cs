    class Program
    {
      static void Main(string[] args)
      {
        var setting = new SettingsItem
        {
          Name = "Setting1",
          Type = SettingTypes.UserSetting,
          Value = "setting"
        };
        XmlSerializer serializer = new XmlSerializer(typeof(SettingsItem));
        StringBuilder sb = new StringBuilder();
        using (StringWriter sr = new StringWriter(sb))
          serializer.Serialize(sr, setting);
        var serialized = sb.ToString();
        Console.WriteLine(serialized);
        SettingsItem item;
        using (var r = new StringReader(sb.ToString()))
          item = (SettingsItem)serializer.Deserialize(r);
        Console.WriteLine("Name: {0}, Type: {1}, Value: {2}", 
          item.Name, 
          item.Type, 
          item.Value);
        Console.ReadKey();
      }
    }
    [Serializable]
    public class SettingsItem
    {
      public string Name { get; set; }
      public SettingTypes Type { get; set; }
      public object Value { get; set; }
    }
    [Flags]
    public enum SettingTypes
    {
      ApplicationSetting = 1,
      UserSetting = 2,
      AdminOnly = 4,
      Temporary = 8
    }
