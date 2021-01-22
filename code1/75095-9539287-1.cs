	enum FamilyRelation { None, Father, Mother, Brother, Sister, };
	class FamilyMember
	{
		public FamilyRelation Relation { get; set; }
		public FamilyMember(FamilyRelation relation)
		{
			this.Relation = relation;
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			FamilyMember member = Create<FamilyMember, FamilyRelation>(FamilyRelation.Sister);
		}
		static T Create<T, P>(P value)
		{
			if (typeof(T).Equals(typeof(FamilyMember)) && typeof(P).Equals(typeof(FamilyRelation)))
			{
				FamilyRelation relation = Enum<FamilyRelation, P>.Convert(value);
				//FamilyRelation relation = (FamilyRelation)(object)value;
				//FamilyRelation relation = (FamilyRelation)value;
				return (T)(object)new FamilyMember(relation);
			}
			throw new NotImplementedException();
		}
	}
