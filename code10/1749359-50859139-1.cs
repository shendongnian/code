        public static string Print(Array array)
        {
            string str = "";
            for (int i = 0; i < array.Length; i++)
            {
                var element = array.GetValue(i);
                if (element is Array)
                {
                    str += "[ ";
                    str += Print(element as Array);
                    str += "]";
                }
                else
                {
                    str += element;
                    if (i < array.Length - 1)
                        str += ", ";
                }
            }
            return str;
        }
