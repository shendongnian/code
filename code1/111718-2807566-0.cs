    public override bool ShouldMap(Member member)
    {
        if ( member.PropertyType.IsGenericType )
        {
            if (member.PropertyType.GetGenericTypeDefinition() == typeof(System.Collections.Generic.IDictionary<,>))
                        return false;
        }
    
        return base.ShouldMap(member);
    }
