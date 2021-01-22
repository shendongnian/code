    [FlagsAttribute]
    public enum DependencyPropertyOptions : byte
    {
               Default = 1,
               ReadOnly = 2,
               Optional = 4,
               DelegateProperty = 32,
               Metadata = 8,
               NonSerialized = 16,
               //EnumPropertyIWantToCommentOutEasily = 32
    }
