    public enum ErrorMessage
    {
        [System.ComponentModel.Description("Request completed successfuly")]
        Success = 100,
        [System.ComponentModel.Description("Missing name in request.")]
        MissingName = 201
    };
    
    public static string GetDescription(this Enum en)
    {
        Type type = en.GetType();
    
        System.Reflection.MemberInfo[] memInfo = type.GetMember(en.ToString());
    
        if (memInfo != null && memInfo.Length > 0)
        {
            object[] attrs = memInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute),
                    false);
    
            if (attrs != null && attrs.Length > 0)
                return ((System.ComponentModel.DescriptionAttribute)attrs[0]).Description;
        }  
    
        return en.ToString();
    }
    
    static void Main(string[] args)
    {
        ErrorMessage message = ErrorMessage.Success;
        Console.WriteLine(message.GetDescription());
    }
