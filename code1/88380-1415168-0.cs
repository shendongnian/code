    /// <summary>
            /// Very good method to Override ToString on Enums
            /// Case : Suppose your enum value is EncryptionProviderType and you want 
            /// enumVar.Tostring() to retrun "Encryption Provider Type" then you should use this method.
            /// Prerequisite : All enum members should be applied with attribute [Description("String to be returned by Tostring()")]
            /// Example : 
            ///  enum ExampleEnum
            ///  {
            ///   [Description("One is one")]
            ///    ValueOne = 1,
            ///    [Description("Two is two")]
            ///    ValueTow = 2
            ///  }
            ///  
            ///  in your class
            ///  ExampleEnum enumVar = ExampleEnum.ValueOne ;
            ///  Console.WriteLine(ToStringEnums(enumVar));
            /// </summary>
            /// <param name="en"></param>
            /// <returns></returns>
            public static string ToStringEnums(Enum en)
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
