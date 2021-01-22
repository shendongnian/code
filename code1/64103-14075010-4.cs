    // NET 4.0
    Boolean mappingInvalid = false;
    emailString = Regex.Replace(emailString, @"(@)(.+)$", match => {
        String domainName = match.Groups[2].Value;
        try {
            domainName = new IdnMapping().GetAscii(domainName);
        } catch (ArgumentException) {
            mappingInvalid = true;
        }
        return match.Groups[1].Value + domainName;
    });
    if (mappingInvalid) {
        return false;
    }
    return Regex.IsMatch(emailString,
            @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$",
            RegexOptions.IgnoreCase);
