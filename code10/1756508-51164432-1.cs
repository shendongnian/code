    [CreateAssetMenu ( fileName = "Settings", menuName = "Settings/Create Settings SO", order = 1 )]
    public class SettingsScriptableObject : ScriptableObject
    {
      public bool testMode;
      public string androidUnitID;
      public string iphoneUnitID;
      //... Any further configuration/settings items you want should go here.
    }
