    var txt = $"<root>{text}</root>";
    var xml = XDocument.Parse(txt);
    var elems = xml.XPathSelectElements("//instance").Select(
        x =>
            {
                var sb = new StringBuilder();
                foreach (var le in x.Elements("label"))
                {
                    sb.Append(", ");
                    sb.Append(le.Element("group") == null ? string.Empty : le.Element("group")?.Value + "=");
                    sb.Append(le.Element("text") == null ? string.Empty : le.Element("text")?.Value);
                }
                if (sb.Length > 0)
                {
                    sb.Remove(0, 2);
                }
                return new { Instance = x, LabelString = sb.ToString() };
            });
