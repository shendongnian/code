	public class UnderscoreCaseElementNameConvention : ConventionBase, IMemberMapConvention
	{
		public void Apply(BsonMemberMap memberMap)
		{
			string name = memberMap.MemberName;
			name = string.Concat(name.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
			memberMap.SetElementName(name);
		}
	}
	
	var pack = new ConventionPack();
    pack.Add(new UnderscoreCaseElementNameConvention());
    
    ConventionRegistry.Register(
        "My Custom Conventions",
        pack,
        t => true);
	
