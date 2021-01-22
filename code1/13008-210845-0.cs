XElement xml = new XElement("contacts",
  new XElement("contact",
    new XAttribute("contactId", ""),
    new XElement("firstName", ""),
    new XElement("lastName", ""),
    new XElement("Address",
        new XElement("Street", ""))
    ),
new XElement("contact",
  new XAttribute("contactId", ""),
  new XElement("firstName", ""),
  new XElement("lastName", "")
   )
 );
var query = from c in xml.Elements()
  where c.Value != ""
  select c;
Console.WriteLine(xml);
Console.WriteLine(query.Count());
</pre>
