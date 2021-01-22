    // From PHP documentation for is_numeric
    // (http://php.net/manual/en/function.is-numeric.php)
    // Finds whether the given variable is numeric.
    // Numeric strings consist of optional sign, any number of digits, optional decimal part and optional
    // exponential part. Thus +0123.45e6 is a valid numeric value.
    // Hexadecimal (e.g. 0xf4c3b00c), Binary (e.g. 0b10100111001), Octal (e.g. 0777) notation is allowed too but
    // only without sign, decimal and exponential part.
    static readonly Regex _isNumericRegex = new Regex(  "^(" +
                                                            /*Hex*/ @"0x[0-9a-f]+"  + "|" +
                                                            /*Bin*/ @"0b[01]+"      + "|" + 
                                                            /*Oct*/ @"0[0-7]+"      + "|" +
                                                            /*Dec*/ @"((?!0)|[-+])(\d*\.)?\d+(e\d+)?" + 
                                                         ")$" );
    static bool IsNumeric( string value )
    {
        return _isNumericRegex.IsMatch( value );
    }
