    var sb = new StringBuilder();
    foreach (var keyValuePair in dictCustomer) {
        if (sb.Length > 0) {
            sb.Append(", ");
        }
        sb.Append(keyValuePair.Key).Append(" ("); // Appends the customer and " (".
        bool nextSite = false;
        foreach (string site in keyValuePair.Value) {
            if (nextSite) {
                sb.Append(", ");
            }
            sb.Append(site);
            nextSite = true;
        }
        sb.Append(")");
    }
    string result = sb.ToString();
