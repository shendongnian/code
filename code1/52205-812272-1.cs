    // Load the whole document into memory, as an element
    XElement root = XElement.Load(xmlReader);
    // Get a sequence of users
    IEnumerable<XElement> users = root.Elements("user");
    // Convert this sequence to a dictionary...
    Dictionary<string, string> userMap = users.ToDictionary(
          element => element.Attribute("name").Value, // Key selector
          element => element.Value);                 // Value selector
