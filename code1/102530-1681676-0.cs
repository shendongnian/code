<code lang="csharp">
using System.Xml.Linq;
...
...
...
XDocument xmlDoc = new XDocument(
                            new XDeclaration("1.0", "utf-16", "true"),
                            new XElement("source",
                                new XElement("publisher","Super X Job Site"),
                                new XElement("publisherurl","http://www.superxjobsite.com")
                            )
                        );
        foreach (Job job in jobs)
        {
            xmlDoc.Element("source").Add(
                new XElement("job",
                    new XElement("title", new XCData(job.Title)),
                    new XElement("date", new XCData(job.Date.ToShortDateString())),
                    new XElement("referencenumber", new XCData(job.ReferenceNumber)),
                    new XElement("url", new XCData(job.Url)),
                    new XElement("company", new XCData(job.Company)),
                    new XElement("city", new XCData(job.City)),
                    new XElement("country", new XCData(job.Country)),
                    new XElement("description", new XCData(job.Description))
                )
            );
        }
