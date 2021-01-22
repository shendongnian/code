    ApplicationSettingsBase settings = passed_in;
    SettingsProvider sp = settings.Providers["LocalFileSettingsProvider"];
    SettingsProperty p = new SettingsProperty("your_prop_name");
    your_class conf = null;
    p.PropertyType = typeof( your_class );
    p.Attributes.Add(typeof(UserScopedSettingAttribute),new UserScopedSettingAttribute());
    p.Provider = sp;
    p.SerializeAs = SettingsSerializeAs.Xml;
    SettingsPropertyValue v = new SettingsPropertyValue( p );
    settings.Properties.Add( p );
    
    settings.Reload();
    conf = (your_class)settings["your_prop_name"];
    if( conf == null )
    {
       settings["your_prop_name"] = conf = new your_class();
       settings.Save();
    }
