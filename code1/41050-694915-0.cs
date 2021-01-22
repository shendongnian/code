    /// <summary>
    /// Escapes the LDAP search filter to prevent LDAP injection attacks.
    /// </summary>
    /// <param name="searchFilter">The search filter.</param>
    /// <see cref="http://blogs.sun.com/shankar/entry/what_is_ldap_injection" />
    /// <see cref="http://msdn.microsoft.com/en-us/library/aa746475.aspx" />
    /// <returns>The escaped search filter.</returns>
    private static string EscapeLdapSearchFilter(string searchFilter)
    {
        StringBuilder escape = new StringBuilder(); // If using JDK >= 1.5 consider using StringBuilder
        for (int i = 0; i < searchFilter.Length; ++i)
        {
            char current = searchFilter[i];
            switch (current)
            {
                case '\\':
                    escape.Append(@"\5c");
                    break;
                case '*':
                    escape.Append(@"\2a");
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
                case '/':
                    escape.Append(@"\2f");
                    break;
                default:
                    escape.Append(current);
                    break;
            }
        }
    
        return escape.ToString();
    }
