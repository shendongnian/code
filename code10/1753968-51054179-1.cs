    protected void SendMessage(string phoneNumber, string message)
    {
        const char CR = '\r'; // "Carage Return"
        const char CtrlZ = (char)26; // Ctrl+Z character
        var header = GeneratePDUHeader(phoneNumber);
        foreach (var messagePart in SplitSMSMessage(message))
        {
            SendToCOM("AT+CMGF=0" + CR);
            SendToCOM("AT+CMGS=42" + CR);
            SendToCOM($"{header}{messagePart}" + CtrlZ);
        }
    }
    // should return something like "0041000B910000000000F000088C"
    protected string GeneratePDUHeader(string phoneNumber) { }
    // split long message to parts
    protected IEnumerable<string> SplitSMSMessage(string message)
    {
        var useUCSEncoding = IsUCSEncodingNeeded(message);
        var partLength = useUCSEncoding ? 67 : 152;
        var messageParts = Enumerable.Range(0, message.Length / partLength)
            .Select(i => message.Substring(i * partLength, partLength))
            .ToArray();
        var referenceNumber = $"{GenerateReferenceNumber():X2}"; // convert to HEX, i.e. "01"
        var totalMessagesCount = $"{messageParts.Length:X2}";    // convert to HEX, i.e. "01"
        var udhBase = $"050003{referenceNumber}{totalMessagesCount}";
        var messageNumber = (char)0;
        foreach (var messagePart in messageParts)
        {
            var udh = $"{udhBase}{++messageNumber}";
            var messagePartText = useUCSEncoding ? StringToUCS(messagePart) : StringToGSM7(messagePart);
            yield return $"{udh}{messagePartText}";
        }
    }
    private void SendToCOM(string message) { } // writes message to COM port
    private bool IsUCSEncodingNeeded(string message) { } // determine if UCS-2 convert is required
    private char GenerateReferenceNumber() { } // random number 0-255
    private string StringToUCS(string message) { } // convert string to UCS encoding
    private string StringToGSM7(string message) { } // convert string to GSM7 encoding (don't forget about padding!)
