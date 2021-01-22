    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace Some.Namespace.Extenders
    {
        public static class StringExtender
        {
            /// <summary>
            /// Evaluates whether the String is contained in AT LEAST one of the passed values (i.e. similar to the "in" SQL clause)
            /// </summary>
            /// <param name="thisString"></param>
            /// <param name="values">list of strings used for comparison</param>
            /// <returns><c>true</c> if the string is contained in AT LEAST one of the passed values</returns>
            public static bool In(this String thisString, params string[] values)
            {
                foreach (string val in values)
                {
                    if (thisString.Equals(val, StringComparison.InvariantCultureIgnoreCase))
                        return true;
                }
    
                return false; //no occurence found
            }
        }
    }
