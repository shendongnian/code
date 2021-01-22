    var logQuery = xDoc.Descendants("logentry")
                   .Where(entry=>
                              entry.Element("author").Value.ToLower().Contains(matchText) ||
                              entry.Element("msg").Value.ToLower().Contains(matchText) ||
                              entry.Element("paths").Value.ToLower().Contains(matchText) ||
                              entry.Element("revision").Value.ToLower().Contains(matchText))
                    .Select(entry=>new
                       {
                           Revision = entry.Attribute("revision").Value,
                           Author = entry.Element("author").Value,
                           CR = LogFormatter.FormatCR(entry.Element("msg").Value),
                           Date = LogFormatter.FormatDate(entry.Element("date").Value),
                           Message = LogFormatter.FormatComment(entry.Element("msg").Value),
                           ET = LogFormatter.FormatET(entry.Element("msg").Value),
                           MergeFrom = LogFormatter.FormatMergeFrom(entry.Element("msg").Value),
                           MergeTo = LogFormatter.FormatMergeTo(entry.Element("msg").Value)
                       });
