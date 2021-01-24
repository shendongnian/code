    var xdoc = XDocument.Parse("YOUR XML DATA");
    var tasks = xdoc.Descendants("task")
                    .GroupBy
                    (
                        t => t.Element("taskCode").Value, // group on taskCode element
                        t => t,
                        (k, g) => new XElement
                        (
                            "task",
                                 new XElement("taskCode", k),
                                 new XElement("taskName", g.Select(x => x.Element("taskName").Value)),
                                 new XElement("supplies", g.Select(x => x.Element("supplies").Element("tool")).ToList()) // merge the "tools"
                        )
                    );
    xdoc.Element("tasks").ReplaceNodes(tasks); // then inject updated nodes back in the xml
