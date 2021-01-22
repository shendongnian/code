    using System;
    public class EnumParser<T> where T : struct
    {
        public static T Parse(int toParse, T defaultVal)
        {
            return Parse(toParse + "", defaultVal);
        }
        public static T Parse(string toParse, T defaultVal) 
        {
            T enumVal = defaultVal;
            if (defaultVal is Enum && !String.IsNullOrEmpty(toParse))
            {
                int index;
                if (int.TryParse(toParse, out index))
                {
                    Enum.TryParse(index + "", out enumVal);
                }
                else
                {
                    if (!Enum.TryParse<T>(toParse + "", true, out enumVal))
                    {
                        MatchPartialName(toParse, ref enumVal);
                    }
                }
            }
            return enumVal;
        }
        public static void MatchPartialName(string toParse, ref T enumVal)
        {
            foreach (string member in enumVal.GetType().GetEnumNames())
            {
                if (member.ToLower().Contains(toParse.ToLower()))
                {
                    if (Enum.TryParse<T>(member + "", out enumVal))
                    {
                        break;
                    }
                }
            }
        }
    }
