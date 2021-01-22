        public static IList<string> ParseCommandLineArgsString(string commandLineArgsString)
        {
            List<string> args = new List<string>();
            commandLineArgsString = commandLineArgsString.Trim();
            if (commandLineArgsString.Length == 0)
                return args;
            int index = 0;
            while (index != commandLineArgsString.Length)
            {
                args.Add(ReadOneArgFromCommandLineArgsString(commandLineArgsString, ref index));
            }
            return args;
        }
        private static string ReadOneArgFromCommandLineArgsString(string line, ref int index)
        {
            if (index >= line.Length)
                return string.Empty;
            var sb = new StringBuilder(512);
            int state = 0;
            while (true)
            {
                char c = line[index];
                index++;
                switch (state)
                {
                    case 0: //string outside quotation marks
                        if (c == '\\') //possible escaping character for quotation mark otherwise normal character
                        {
                            state = 1;
                        }
                        else if (c == '"') //opening quotation mark for string between quotation marks
                        {
                            state = 2;
                        }
                        else if (c == ' ') //closing arg
                        {
                            return sb.ToString();
                        }
                        else
                        {
                            sb.Append(c);
                        }
                        break;
                    case 1: //possible escaping \ for quotation mark or normal character
                        if (c == '"') //If escaping quotation mark only quotation mark is added into result
                        {
                            state = 0;
                            sb.Append(c);
                        }
                        else // \ works as not-special character
                        {
                            state = 0;
                            sb.Append('\\');
                            index--;
                        }
                        break;
                    case 2: //string between quotation marks
                        if (c == '"') //quotation mark in string between quotation marks can be escape mark for following quotation mark or can be ending quotation mark for string between quotation marks
                        {
                            state = 3;
                        }
                        else if (c == '\\') //escaping \ for possible following quotation mark otherwise normal character
                        {
                            state = 4;
                        }
                        else //text in quotation marks
                        {
                            sb.Append(c);
                        }
                        break;
                    case 3: //quotation mark in string between quotation marks
                        if (c == '"') //Quotation mark after quotation mark - that means that this one is escaped and can added into result and we will stay in string between quotation marks state
                        {
                            state = 2;
                            sb.Append(c);
                        }
                        else //we had two consecutive quotation marks - this means empty string but the following chars (until space) will be part of same arg result as well
                        {
                            state = 0;
                            index--;
                        }
                        break;
                    case 4: //possible escaping \ for quotation mark or normal character in string between quotation marks
                        if (c == '"') //If escaping quotation mark only quotation mark added into result
                        {
                            state = 2;
                            sb.Append(c);
                        }
                        else
                        {
                            state = 2;
                            sb.Append('\\');
                            index--;
                        }
                        break;
                }
                if (index == line.Length)
                    return sb.ToString();
            }
        }
