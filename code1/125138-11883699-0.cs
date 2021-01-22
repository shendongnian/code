		Mapper.CreateMap<tempOR_Order, OR_Order>()
			.ForMember(m => m.OR_ID, exp => exp.Ignore())
			.ForMember(m => m.OR_CU_ID, exp => exp.Ignore())
			.ForAllMembers(o => o.Condition(ctx =>
			{
				var members = ctx.Parent.SourceType.GetMember(ctx.MemberName); // get the MemberInfo that we are mapping
				if (!members.Any())
				{
					members = ctx.Parent.SourceType.GetMember("temp" + ctx.MemberName);
					if (!members.Any())
						return false;
				}
				return members.First().GetCustomAttributes(typeof(EdmScalarPropertyAttribute), false).Any(); // determine if the Member has the EdmScalar attribute set
			}));
