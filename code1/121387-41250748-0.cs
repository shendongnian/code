    using System;
    using System.Collections.Generic;
    using System.Text;
    class CsvParser
    {
        public static List<string> Parse(string line)
        {
            const char escapeChar = '"';
            const char splitChar = ',';
            bool inEscape = false;
            bool priorEscape = false;
            List<string> result = new List<string>();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                switch (c)
                {
                    case escapeChar:
                        if (!inEscape)
                            inEscape = true;
                        else
                        {
                            if (!priorEscape)
                            {
                                if (i + 1 < line.Length && line[i + 1] == escapeChar)
                                    priorEscape = true;
                                else
                                    inEscape = false;
                            }
                            else
                            {
                                sb.Append(c);
                                priorEscape = false;
                            }
                        }
                        break;
                    case splitChar:
                        if (inEscape) //if in escape
                            sb.Append(c);
                        else
                        {
                            result.Add(sb.ToString());
                            sb.Length = 0;
                        }
                        break;
                    default:
                        sb.Append(c);
                        break;
                }
            }
            if (sb.Length > 0)
                result.Add(sb.ToString());
            return result;
        }
    }
