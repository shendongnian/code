    public IEnumerable<string> GetIdProperties(EntitySetBase entitySet)
    {
      return GetIdProperties(entitySet.ElementType);
    }
    public IEnumerable<string> GetIdProperties(EntityTypeBase entityType)
    {
      return from keyMember in entityType.KeyMembers
             select keyMember.Name
    }
