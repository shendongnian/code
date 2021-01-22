    public enum MyEnum
    {
        [Description("Option One")]
                Option_One
    }
        
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Enum"></param>
    /// <returns></returns>
    public static string ToDescriptionString(this Enum Enum)
    {
        //Get name
        string Name = Enum.GetName(Enum.GetType(),Enum);
           
        //Get member
        MemberInfo Member = Enum.GetType().GetMembers().Where(w => w.Name == Name).FirstOrDefault();
    
        //Get Attribute
        DescriptionAttribute Description = Member != null 
           ? Member.GetCustomAttributes(true).Where(w => w.GetType() ==  typeof(DescriptionAttribute)).FirstOrDefault() as DescriptionAttribute
           : null;
               
           return Description != null ? Description.Description : Name;
    }
