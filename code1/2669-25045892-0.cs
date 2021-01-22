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
            if (defaultVal is Enum)
            {
                int index;
                if (int.TryParse(toParse, out index))
                {
                    Enum.TryParse(index + "", out enumVal);
                }
                else
                {
                    foreach (string member in defaultVal.GetType().GetEnumNames())
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
            return enumVal;
        }
    }
