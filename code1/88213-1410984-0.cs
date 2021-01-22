       public class Travel 
       {
           private LocalizedString props = new LocalizedString();
           public LocalizedString Propertys
           {
              get { return props; }
              set { props = value; }
           }
       }
       public class LocalizedString // this is property Bag emulator
       {
           public string this[string resourceName]
           {
               get{ return LocaleHelper.GetRessource(resourceName); }
               set{ LocaleHelper.GetRessource(resourceName) = value; }
           }
       }
