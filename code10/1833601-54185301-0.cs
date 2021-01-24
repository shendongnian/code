    var xml = XElement.Parse(result);
    var data = xml
               .Elements()
               .Select(e => new { SenderNumber = e.Element("SenderNumber").Value,
                                  TextDecoded = e.Element("TextDecoded").Value });
    // iterate over collection
    data.ToList().ForEach(e => Console.WriteLine($"Sender: {e.SenderNumber}, " +
                                                 $"TextDecoded: {e.TextDecoded}"));
