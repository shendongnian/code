    using System;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    [JsonConverter(typeof(StringEnumConverter))]
    public enum MyType
    {
        [EnumMember(Value = "person")]
        Person,
        [EnumMember(Value = "annan_deltagare")]
        OtherPerson,
        [EnumMember(Value = "regel")]
        Rule,
    }
