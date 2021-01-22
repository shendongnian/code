var derived_types = new List<Type>();
foreach (var domain_assembly in AppDomain.CurrentDomain.GetAssemblies())
{
  var assembly_types = domain_assembly.GetTypes()
    .Where(type => type.IsSubclassOf(typeof(MyType)) && !type.IsAbstract);
  derived_types.AddRange(assembly_types);
}
In my case I used `type.IsSubClassOf(MyType)` because I only wanted derived types excluding the base class like mentioned above. I also needed the derived types not to be abstract (`!type.IsAbstract`) so I am also excluding derived abstract classes.
