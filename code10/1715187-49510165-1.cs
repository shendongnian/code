    namespace MyEvilness {
        class TableAttribute : Attribute {
            public TableAttribute(string configSetting) {
                 Name = LookupTableNameFromConfig(configSetting);
            }
            // etc as before
        }
    }
