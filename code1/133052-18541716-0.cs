    ...//snip
    ....Mappings(m => m.AutoMappings.Add(
                        AutoMap.AssemblyOf<Account>()
                         //Use my mapping overrides here 
                        .UseOverridesFromAssemblyOf<MyMappingOverride>()
                        .Conventions.Add(new MyConventions()).IgnoreBase<Entity>
                    ))
					
