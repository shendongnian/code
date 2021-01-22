    public static class Program
    {
       static void Main(string[] args)
        {
           // display the description attribute from the enum
           foreach (Colour type in (Colour[])Enum.GetValues(typeof(Colour)))
           {
                Console.WriteLine(EnumExtensions.ToName(type));
           }
           // Get the array from the description
           string xStr = "Yellow";
           Colour thisColour = EnumExtensions.FromName<Colour>(xStr);
           Console.ReadLine();
        }
       public enum Colour
       {
           [Description("Colour Red")]
           Red = 0,
           [Description("Colour Green")]
           Green = 1,
           [Description("Colour Blue")]
           Blue = 2,
           Yellow = 3
       }
    }
    public static class EnumExtensions
    {
        // This extension method is broken out so you can use a similar pattern with 
        // other MetaData elements in the future. This is your base method for each.
        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            // check if no attributes have been specified.
            if (((Array)attributes).Length > 0)
            {
                return (T)attributes[0];
            }
            else
            {
                return null;
            }
        }
        // This method creates a specific call to the above method, requesting the
        // Description MetaData attribute.
        public static string ToName(this Enum value)
        {
            var attribute = value.GetAttribute<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;
        }
        /// <summary>
        /// Find the enum from the description attribute.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="desc"></param>
        /// <returns></returns>
        public static T FromName<T>(this string desc) where T : struct
        {
            string attr;
            Boolean found = false;
            T result = (T)Enum.GetValues(typeof(T)).GetValue(0);
            foreach (object enumVal in Enum.GetValues(typeof(T)))
            {
                attr = ((Enum)enumVal).ToName();
                if (attr == desc)
                {
                    result = (T)enumVal;
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                throw new Exception();
            }
            return result;
        }
    }
}
