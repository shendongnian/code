        //---------------------------------------------------------------
        // Get title case of a string (every word with leading upper case,
        //                             the rest is lower case)
        //    i.e: ABCD EFG -> Abcd Efg,
        //         john doe -> John Doe,
        //         miXEd CaSING - > Mixed Casing
        //---------------------------------------------------------------
        public static string ToTitleCase(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower());
        }
