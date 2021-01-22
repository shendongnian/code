    var cfg = Fluently.Configure()
    			.Database(configurer)
    			.Mappings(m =>
    						{
    							m.AutoMappings.Add(AutoMap.Assemblies(Assembly.GetExecutingAssembly())
    								.Override<Team>(map => map.IgnoreProperty(team => team.TeamMembers)));
    						});
						
