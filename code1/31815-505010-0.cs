    var elements = xDocument.Descendants(w + "sdt")
                       .Concat(otherDocument.Descendants(w + "sdt")
                                   .Where(e => !xDocument.Descendants(w + "sdt")
                                                   .Any(x => x.Element(w + "sdtPr")
                                                                 .Element(w + "tag")
                                                                 .Attribute(w + "val").Value ==
                                                             e.Element(w + "sdtPr")
                                                                 .Element(w + "tag")
                                                                 .Attribute(w + "val").Value)))
                       .Select(sdt =>
                           new XElement(
                               sdt.Element(w + "sdtPr")
                                   .Element(w + "tag")
                                   .Attribute(w + "val").Value,
                               GetTextFromContentControl(sdt).Trim())
                       )
                   );
