    public override bool ShouldMap(Member member)
    {
        var prop = member.DeclaringType.GetProperty(member.Name);
        bool isPropertyToMap = 
            prop != null &&
            prop.GetSetMethod(true) != null &&
            member.IsProperty;
    
        return
            base.ShouldMap(member) && isPropertyToMap;
    }
