    #region MatchDoubleMinMaxValuesRegex
    /// <summary>
    /// This regex matches strings which represents either a <see cref="double.MinValue"/> or a <see cref="double.MaxValue"/>.
    /// If it is a <see cref="double.MinValue"/> then the group "isNegative" will be matched as <see cref="Group.Success"/>.
    /// </summary>
    private static readonly Regex MatchDoubleMinMaxValuesRegex = new Regex(
        @"
            ^
            (?>(?<isNegative>-)|\+?)
            1
            (?>[,.]?)
            79769313486232
            (?>
                [eE]\+308|
                0{294}(?>[,.]|$)
            )
        ",
        RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace
    );
    #endregion
    /// <summary>
    /// Converts the string representation of a number in a specified culture-specific format to its double-precision floating-point number equivalent.
    /// <para>This implementation is more tolerant compared to the native double.Parse implementation:
    /// strings representing <see cref="double.MinValue"/> and <see cref="double.MaxValue"/> can be parsed without <see cref="OverflowException"/>.</para>
    /// </summary>
    /// <param name="s">A string that contains a number to convert.</param>
    /// <param name="cultureInfo">For some type conversions optional culture information that shall be used to parse the value.
    /// If not specified, then the Current Culture will be used.</param>
    /// <param name="numberStyles">For some type conversions optional number style configuration that shall be used to parse the value.
    /// If not specified, then the default will be used.</param>
    /// <returns>A double-precision floating-point number that is equivalent to the numeric value or symbol specified in <paramref name="s"/>.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="s"/> is <c>null</c>.</exception>
    /// <exception cref="FormatException"><paramref name="s"/> does not represent a number in a valid format.</exception>
    /// <exception cref="OverflowException"><paramref name="s"/> represents a number that is less than <see cref="double.MinValue"/> or greater than <see cref="double.MaxValue"/>.</exception>
    public static double ParseDoubleEx(string s, CultureInfo cultureInfo = null, NumberStyles? numberStyles = null)
    {
        // Try parse
        double tempValue;
        bool parseSuccess = (numberStyles != null)
            ? double.TryParse(s, numberStyles.Value, cultureInfo, out tempValue)
            : double.TryParse(s, NumberStyles.Any, cultureInfo, out tempValue);
        // If parsing failed, check for Min or Max Value (by pattern)
        if (parseSuccess == false)
        {
            Match match = MatchDoubleMinMaxValuesRegex.Match(s);
            if (match.Success == true)
                tempValue = (match.Groups["isNegative"].Success == false)
                    ? double.MaxValue
                    : double.MinValue;
            else
                throw new OverflowException("A double-precision floating-point number that is equivalent to the numeric value or symbol specified in s.");
        }
        return tempValue;
    }
