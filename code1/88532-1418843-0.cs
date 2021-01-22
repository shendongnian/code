PersistenceModel = AutoPersistenceModel
        .MapEntitiesFromAssemblyOf<<User>>()
        .Where(type => type.Namespace != null && type.Namespace.Contains("Model"))
        .WithSetup(s =>
                     {
                       s.IsBaseType = type => type ==  typeof (DateTimeBase)
                                              || type == typeof (SimpleBase);
                     })
        .ConventionDiscovery.AddFromAssemblyOf<ReferenceConvention>();</code></pre>
Then I add the persistence model to the automappings.  I use the ExportTo method to get a copy of the generated xml files - looking at the xml helps to diagnose some problems.
.Mappings(m => m.AutoMappings
                         .Add(persistenceModel)
                         .ExportTo(@"../../ExportAutoMaps"));</code></pre>
AutoMapping has worked great for me - though it did take time to learn and experiment.<br>
I am using jet database and I have to explicitly create my database file for NHibernate to run the schema on.  I am unfamiliar with how sqlLite works.
