    public static string ToEnumDescription(this Enum en) //ext method
    {
    	Type type = en.GetType();
    	MemberInfo[] memInfo = type.GetMember(en.ToString());
    	if (memInfo != null && memInfo.Length > 0)
    	{
    		object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
    		if (attrs != null && attrs.Length > 0)
    			return ((DescriptionAttribute)attrs[0]).Description;
    	}
    	return en.ToString();
    }
    public enum ActivityType
    {
    	[Description("Drip Plan Email")]
    	DripPlanEmail = 1,
    	[Description("Modification")]
    	Modification = 2,
    	[Description("View")]
    	View = 3,
    	[Description("E-Alert Sent")]
    	EAlertSent = 4,
    	[Description("E-Alert View")]
    	EAlertView = 5
    }
