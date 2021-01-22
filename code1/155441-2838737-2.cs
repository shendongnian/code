    //
    // Summary:
    //     Replaces the format item in a specified string with the string representation
    //     of a corresponding object in a specified array. A specified parameter supplies
    //     culture-specific formatting information.
    //
    // Parameters:
    //   provider:
    //     An object that supplies culture-specific formatting information.
    //
    //   format:
    //     A composite format string.
    //
    //   args:
    //     An object array that contains zero or more objects to format.
    //
    // Returns:
    //     A copy of format in which the format items have been replaced by the string
    //     representation of the corresponding objects in args.
    //
    // Exceptions:
    //   System.ArgumentNullException:
    //     format or args is null.
    //
    //   System.FormatException:
    //     format is invalid.-or- The index of a format item is less than zero, or greater
    //     than or equal to the length of the args array.
    [SecuritySafeCritical]
    public static string Format(IFormatProvider provider, string format, params object[] args);
