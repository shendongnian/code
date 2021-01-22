    /// <summary>
    /// Convert a byte count into a human readable size string.
    /// </summary>
    /// <param name="bytes">The byte count.</param>
    /// <param name="si">Whether or not to use SI units.</param>
    /// <returns>A human readable size string.</returns>
    public static string ToHumanReadableByteCount(
        this long bytes
        , bool si
    )
    {
        var unit = si
            ? 1000
            : 1024;
        if (bytes < unit)
        {
            return $"{bytes} B";
        }
        var exp = (int) (Math.Log(bytes) / Math.Log(unit));
        return $"{bytes / Math.Pow(unit, exp):F2} " +
               $"{(si ? "kMGTPE" : "KMGTPE")[exp - 1] + (si ? string.Empty : "i")}B";
    }
