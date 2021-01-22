    /// <summary>
    /// The regular expression to test the string against.
    /// </summary>
    private static readonly Regex validEmailRegex = new Regex(
        @"^(([^<>()[\]\\.,;:\s@\""]+"
        + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
        + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
        + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
        + @"[a-zA-Z]{2,}))$",
        RegexOptions.Compiled);
    /// <summary>
    /// Determines whether the specified string is a valid email address.
    /// </summary>
    /// <param name="value">
    /// The string to validate.
    /// </param>
    /// <returns>
    /// <c>true</c> if the specified string is a valid email address;
    /// otherwise, <c>false</c>.
    /// </returns>
    public static bool IsValidEmailAddress(this string value)
    {
        if (!validEmailRegex.IsMatch(value))
        {
            return false;
        }
        var mailServer = new DNS().LookupMX(value.Split('@')[1]);
        if (!mailServer.MoveNext())
        {
            return false;
        }
        var telnet = new TelnetConnection(((DNS_MX_DATA)((DNS_WRAPPER)mailServer.Current).dnsData).pNameExchange, 25);
        try
        {
            if (!TelnetCompare(telnet.Read(), "220"))
            {
                return false;
            }
            telnet.WriteLine("helo hi");
            if (!TelnetCompare(telnet.Read(), "250"))
            {
                return false;
            }
            telnet.WriteLine("mail from: " + value);
            if (!TelnetCompare(telnet.Read(), "250"))
            {
                return false;
            }
            telnet.WriteLine("rcpt to: " + value);
            if (!TelnetCompare(telnet.Read(), "250"))
            {
                return false;
            }
        }
        finally
        {
            telnet.WriteLine("quit");
        }
        return true;
    }
    /// <summary>
    /// Compares two strings for length and content from the Telnet stream.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <param name="response">The desired response.</param>
    /// <returns>true if the response is the first characters if the input,
    /// false otherwise</returns>
    private static bool TelnetCompare(string input, string response)
    {
        if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(response))
        {
            return false;
        }
        if (input.Length < response.Length)
        {
            return false;
        }
        return string.CompareOrdinal(input.Substring(0, response.Length), response) == 0;
    }
