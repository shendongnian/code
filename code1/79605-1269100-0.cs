     protected override RuleSet GetRulesFromTypeCore(Type type)
     {
       var typeDescriptor = metadataProviderFactory(type).GetTypeDescriptor(type);
       var rules = (from prop in typeDescriptor.GetProperties().Cast<PropertyDescriptor>()
                             from rule in GetRulesFromProperty(prop)
                             select new KeyValuePair<string, Rule>(prop.Name, rule));
    
       var metadataAttrib = type.GetCustomAttributes(typeof(MetadataTypeAttribute), true).OfType<MetadataTypeAttribute>().FirstOrDefault();
       var buddyClassOrModelClass = metadataAttrib != null ? metadataAttrib.MetadataClassType : type;
       var buddyClassProperties = TypeDescriptor.GetProperties(buddyClassOrModelClass).Cast<PropertyDescriptor>();
       var modelClassProperties = TypeDescriptor.GetProperties(type).Cast<PropertyDescriptor>();
    
       var buddyRules =  from buddyProp in buddyClassProperties
                                  join modelProp in modelClassProperties on buddyProp.Name equals modelProp.Name
                                  from rule in GetRulesFromProperty(buddyProp)
                                  select new KeyValuePair<string, Rule>(buddyProp.Name, rule);
                           
       rules = rules.Union(buddyRules);
       return new RuleSet(rules.ToLookup(x => x.Key, x => x.Value));
     }
