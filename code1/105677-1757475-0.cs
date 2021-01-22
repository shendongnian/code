    public override ProblemCollection Check(Member member)
	{
		if (member is Method)
		{
			this.Visit(member);
		}
		return this.Problems;
	}
	public override void VisitConstruct(Construct construct)
	{
		base.VisitConstruct(construct);
		TypeNode constructedType = ((MemberBinding)construct.Constructor).BoundMember.DeclaringType;
		if (!this.AllowTypeToBeNewed(constructedType))
		{
			this.Problems.Add(new Problem(this.GetResolution(), construct));
		}
	}
	private bool AllowTypeToBeNewed(TypeNode type)
	{
		throw new NotImplementedException();
	}
