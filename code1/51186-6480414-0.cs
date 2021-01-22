        enum HowNice
        {
            ReallyNice,
            SortOfNice,
            NotNice
        }
        /// <summary>
        /// This method is for filling a listcontrol,
        /// such as dropdownlist, listbox... 
        /// with an enum as the datasource.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ctrl"></param>
        /// <param name="resourceClassName"></param>
        public static void OwFillDataWithEnum<T>(ListControl ctrl, string resourceClassName)
        {
            var owType = typeof(T);
            var values = Enum.GetValues(owType);
            for (var i = 0; i < values.Length; i++)
            {
                //Localize this for displaying listcontrol's text field.
                var text = OwToStringByCulture(resourceClassName, Enum.Parse(owType, values.GetValue(i).ToString()).ToString());
                //This is for listcontrol's value field
                var key = (Enum.Parse(owType, values.GetValue(i).ToString()));
                //add values of enum to listcontrol.
                ctrl.Items.Add(new ListItem(text, key.ToString()));
            }
        }
        /// <summary>
        /// Get localized strings.
        /// </summary>
        /// <param name="resourceClassName"></param>
        /// <param name="resourceKey"></param>
        /// <returns></returns>
        public static string OwToStringByCulture(string resourceClassName, string resourceKey)
        {
                return (string)HttpContext.GetGlobalResourceObject(resourceClassName, resourceKey);
        }
}
