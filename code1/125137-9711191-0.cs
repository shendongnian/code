    AutoMapper.Mapper.CreateMap<EntityType, EntityType>()
        .ForAllMembers(o => {
             o.Condition(ctx =>
                 {
                     var members = ctx.Parent.SourceType.GetMember(ctx.MemberName); // get the MemberInfo that we are mapping
                    if (!members.Any())
                        return false;
                    return members.First().GetCustomAttributes(typeof(EdmScalarPropertyAttribute), false).Any(); // determine if the Member has the EdmScalar attribute set
                });
        });
