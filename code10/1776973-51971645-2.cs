    var xdoc = XDocument.Parse("YOUR XML DATA");
    var tasks = xdoc.Descendants("task")
                    .GroupBy
                    (
                        t => t.Element("taskCode").Value, // group on taskCode value
                        t => t,
                        (k, g) => new XElement // Make a new "task" element
                        (
                            "task",
                                 new XElement("taskCode", k), // with the taskCode
                                 g.Select(x => x.Element("taskName")).FirstOrDefault(), // taskName, just pick the first one
                                 new XElement("supplies", g.Select(x => x.Element("supplies").Element("tool")).ToList()) // merge the "tools"
                        )
                    );
    xdoc.Element("tasks").ReplaceNodes(tasks); // then inject updated nodes back in the xml
