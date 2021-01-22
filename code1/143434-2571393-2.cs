    public bool TryParseGuid(string value, out Guid result) {
        try {
            result = new Guid(value.Replace("-", ""); // needed to cater for wron hyphenation
            return true;
        } catch {
            result = Guid.Empty;
            return false;
        }
    }
