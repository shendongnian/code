private static string GetFormattedAddress(
    string address1,
    string address2,
    string city,
    string state,
    string zip)
{
    var addressItems =
        new []
        {
            new[] { address1, "\n" },
            new[] { address2, "\n" },
            new[] { city, ", " },
            new[] { state, " " },
            new[] { zip, null }
        };
    string suffix = null;
    var sb = new StringBuilder(128);
    foreach (var item in addressItems)
    {
        if (!string.IsNullOrWhiteSpace(item[0]))
        {
            // Append the last item's suffix
            sb.Append(suffix);
            // Append the address component
            sb.Append(item[0]);
            // Cache the suffix
            suffix = item[1];
        }
    }
    return sb.ToString();
}
