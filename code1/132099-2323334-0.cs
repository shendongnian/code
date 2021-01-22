    public class ColorElement : ConfigurationElement
        {
            [ConfigurationProperty("background", DefaultValue = "FFFFFF", IsRequired = true)]
            [StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\GHIJKLMNOPQRSTUVWXYZ", MinLength = 6, MaxLength = 6)]
            public String Background
            {
                get
                {
                    return (String)this["background"];
                }
                set
                {
                    this["background"] = value;
                }
            }
        }
