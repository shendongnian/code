        /// <summary>
        /// Escapes the LDAP search filter to prevent LDAP injection attacks.
        /// </summary>
        private static string EscapeLdapSearchFilter(string searchFilter)
        {
            StringBuilder escape = new StringBuilder();
            for (int i = 0; i < searchFilter.Length; ++i)
            {
                char current = searchFilter[i];
                switch (current)
                {
                    case '\\':
                        escape.Append(@"\5c");
                        break;
                    case '/':
                        escape.Append(@"\2f");
                        break;
                    case '(':
                        escape.Append(@"\28");
                        break;
                    case ')':
                        escape.Append(@"\29");
                        break;
                    case '\u0000':
                        escape.Append(@"\00");
                        break;
                    case '*':
                        escape.Append(@"\2a");
                        break;
                    default:
                        escape.Append(current);
                        break;
                }
            }
            return escape.ToString();
        }
        /// <summary>
        /// When renaming a DirectoryEntry via "DE.Rename(newCN)" 
        /// you will need to escape certain character(s) ... ex. "," to "\,"
        /// </summary>
        private static string EscapeFullNameFilter(string unescapedString)
        {
            StringBuilder escape = new StringBuilder();
            for (int i = 0; i < unescapedString.Length; ++i)
            {
                char current = unescapedString[i];
                switch (current)
                {
                    case '\\':
                    case ',':
                    case ';':
                    case '"':
                    case '=':
                    case '+':
                    case '<':
                    case '>':
                    case '#':
                        escape.Append(@"\"); //We need to show to escape the current char, so we add this before it.
                        escape.Append(current);
                        break;
                    default:
                        escape.Append(current);
                        break;
                }
            }
            return escape.ToString();
        }
