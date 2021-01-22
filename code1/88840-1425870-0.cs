    public bool ValidateAllDistinct(Type enumType)
    {
        return !Enum.GetNames(enumType).All(outerName
            => Enum.GetNames(enumType).Any(innerName
                => innerName == outerName 
                    ? true 
                    : Enum.Parse(enumType, innerName) != Enum.Parse(enumType, outerName)));
    }
