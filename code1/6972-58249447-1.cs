    List<int> listEnumValues = new List<int>();
    YourEnumType[] myEnumMembers = (YourEnumType[])Enum.GetValues(typeof(YourEnumType));
    foreach ( YourEnumType enumMember in myEnumMembers)
    {
        listEnumValues.Add(enumMember.GetHashCode());
    }
