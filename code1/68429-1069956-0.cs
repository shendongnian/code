public IDictionary<string, string> AddWordsToDictionary(IList<string> words)
{
    IDictionary<string, string> addressParts = new Dictionary<string, string>();
    addressParts.Add("Address1", string.Empty);
    addressParts.Add("Address2", string.Empty);
    addressParts.Add("Address3", string.Empty);
    int currentIndex = 1;
    foreach (string word in words)
    {
        if (!string.IsNullOrEmpty(word))
        {
            string key = string.Concat("Address", currentIndex);
            int space = 0;
            string spaceChar = string.Empty;
            if (!string.IsNullOrEmpty(addressParts[key]))
            {
                space = 1;
                spaceChar = " ";
            }
            if (word.Length + space + addressParts[key].Length > MaxAddressLineLength)
            {
                currentIndex++;
                key = string.Concat("Address", currentIndex);
                space = 0;
                spaceChar = string.Empty;
                if (currentIndex > addressParts.Count)
                {
                    break; // To big for all 3 elements so discard
                }
            }
            addressParts[key] = string.Concat(addressParts[key], spaceChar, word);
        }
    }
    return addressParts;
}
