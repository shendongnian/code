    [DataContract]
    public enum ControlSelectionType
    {
        [EnumMember(Value = "Not Applicable")]
        NotApplicable = 1,
        [EnumMember(Value = "Single Select Radio Buttons")]
        SingleSelectRadioButtons = 2,
        [EnumMember(Value = "Completely Different Display Text")]
        SingleSelectDropDownList = 3,
    }
    public static string GetDescriptionFromEnumValue(Enum value)
    {
        EnumMemberAttribute attribute = value.GetType()
            .GetField(value.ToString())
            .GetCustomAttributes(typeof(EnumMemberAttribute), false)
            .SingleOrDefault() as EnumMemberAttribute;
        return attribute == null ? value.ToString() : attribute.Value;
    }
