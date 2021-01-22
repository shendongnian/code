     var assemblies = AppDomain.CurrentDomain.GetAssemblies()
				.Where(a => a.GetName().Name.StartsWith("MyCompany"));
    
    var types =         from asm in assemblies
                        from type in asm.GetTypes()
    			where Regex.IsMatch(type.FullName,"MyRegexp")
    			select type.Name;
