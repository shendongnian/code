    var map = AutoMapper.Mapper.Configuration.FindTypeMapFor<Person, PersonDto>();
    foreach (var propertyMap in map.PropertyMaps)
    {
        var destProp = propertyMap.DestinationMember.Name; // = "FullName"
        var sourceMember = propertyMap.SourceMember?.Name; // = "LastName" (I don't care)
        var sourceMembers = propertyMap.SourceMembers.ToList();
        if (sourceMembers.Count() == 0)
        {
            ResolveSourceMembersInOrder(sourceMembers,
                propertyMap.CustomMapExpression.Body as BinaryExpression);
        }
        
        // sourceMembers now yield the two desired sourceMembers "FirstName" and "LastName"
    }
    public static void ResolveSourceMembersInOrder(List<MemberInfo> memberInfos, BinaryExpression expression)
    {
        if (memberInfos == null)
        {
            memberInfos = new List<MemberInfo>();
        }
        if (expression == null)
        {
            return;
        }
        var left = expression.Left;
        if (left.NodeType == ExpressionType.MemberAccess)
        {
            memberInfos.Add(MemberVisitor.GetMemberPath(left).FirstOrDefault());
        }
        else
        {
            ResolveSourceMembersInOrder(memberInfos, left as BinaryExpression);
        }
        var right = expression.Right;
        if (right.NodeType == ExpressionType.MemberAccess)
        {
            memberInfos.Add(MemberVisitor.GetMemberPath(right).FirstOrDefault());
        }
        else
        {
            ResolveSourceMembersInOrder(memberInfos, right as BinaryExpression);
        }
    }
