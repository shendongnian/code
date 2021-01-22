     public static class ConfigurationManagerWrapper
     {
          public static ConfigurationSection GetSection( string name )
          {
             return ConfigurationManager.GetSection( name );
          }
          .....
          public static ConfigurationSection GetWidgetSection()
          {
              return GetSection( "widgets" );
          }
     }
