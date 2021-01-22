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
				FamilyRelation rel = Identity<FamilyRelation, P>.Cast(value);
				return (T)(object)new FamilyMember(rel);
			}
			throw new NotImplementedException();
		}
	}
