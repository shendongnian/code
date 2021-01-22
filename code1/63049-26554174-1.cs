    static class Animals
    {
        public static Type AnimalType(this Enum value )
        {
            var member = value.GetType().GetMember(value.ToString()).FirstOrDefault();
            // this assumes a single animal attribute            
            return member == null ? null :
                member.GetCustomAttributes()
                    .Where(at => at is AnimalAttribute)
                    .Cast<AnimalAttribute>().FirstOrDefault().GetType();
        }
        
        public static bool IsCat(this Enum value) { return value.HasAttribute<CatAttribute>(); }
        
        public static bool IsDog(this Enum value) { return value.HasAttribute<DogAttribute>(); }
        
        public static bool IsAnimal(this Enum value) { return value.HasAttribute<AnimalAttribute>(); }
        
        public static bool IsReptile(this Enum value) { return value.HasAttribute<ReptileAttribute>(); }
        
        public static bool IsSnake(this Enum value) { return value.HasAttribute<SnakeAttribute>(); }
        
        public static bool IsLizard(this Enum value) { return value.HasAttribute<LizardAttribute>(); }
        public static bool HasAttribute<T>(this Enum value)
        {
            var member = value.GetType().GetMember(value.ToString()).FirstOrDefault();
            return member != null && Attribute.IsDefined(member, typeof(T));
        }
        
        public static string ToString<T>(this Animal value) where T : AnimalAttribute
        {
            var type = value.AnimalType();
            var s = "";
            while( type != null && !(type == typeof(Object)) )
            {
                s = type.Name.Replace("Attribute","") + "."+s;
                type = type.BaseType;
            }
            
            return s.Trim('.');
        }
    }
