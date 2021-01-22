        /// <summary>
        /// Returns the value of the description attribute attached to an enum value.
        /// </summary>
        /// <param name="en"></param>
        /// <returns>The text from the System.ComponentModel.DescriptionAttribute associated with the enumeration value.</returns>
        /// <remarks>
        /// To use this, create an enum and mark its members with a [Description("My Descr")] attribute.
        /// Then when you call this extension method, you will receive "My Descr".
        /// </remarks>
        /// <example><code>
        /// enum MyEnum {
        ///     [Description("Some Descriptive Text")]
        ///     EnumVal1,
        ///
        ///     [Description("Some More Descriptive Text")]
        ///     EnumVal2
        /// }
        /// 
        /// static void Main(string[] args) {
        ///     Console.PrintLine( MyEnum.EnumVal1.GetDescription() );
        /// }
        /// </code>
        /// 
        /// This will result in the output "Some Descriptive Text".
        /// </example>
        public static string GetDescription(this Enum en)
        {
            var type = en.GetType();
            var memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return en.ToString();
        }
