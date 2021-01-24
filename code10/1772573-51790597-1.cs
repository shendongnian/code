    var customers = new List<KeyValuePair<string, List<string>>>(dictCustomer);
    customers.Sort((a, b) => a.Key.CompareTo(b.Key));
    var sb = new StringBuilder();
    foreach (var keyValuePair in customers) {
        if (sb.Length > 0) {
            sb.Append(", ");
        }
        sb.Append(keyValuePair.Key).Append(" (");
        keyValuePair.Value.Sort(); // Sorting the list of sites.
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
