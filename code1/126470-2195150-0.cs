    [Guid("00000000-0000-0000-0000-000000000000"), ComVisible(true)]
    [TargetExtension(".txt", true)]
    public class SampleExtension : ContextMenuExtension
    {
       protected override void OnGetMenuItems(GetMenuitemsEventArgs e)
       {
          e.Menu.AddItem("Sample Extension", "sampleverb", "Status/help text");
       }
       protected override bool OnExecuteMenuItem(ExecuteItemEventArgs e)
       {
          if (e.MenuItem.Verb == "sampleverb")
             ; // logic
          return true;
       }
       [ComRegisterFunction]
       public static void Register(Type t)
       {
          ContextMenuExtension.RegisterExtension(typeof(SampleExtension));
       }
       [ComUnregisterFunction]
       public static void UnRegister(Type t)
       {
          ContextMenuExtension.UnRegisterExtension(typeof(SampleExtension));
       }
    }
