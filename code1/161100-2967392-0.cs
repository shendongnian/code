    var xml = @"<TimelineInfo>
                    <PreTrialEd>Not Started</PreTrialEd>
                    <Ambassador>Problem</Ambassador>
                    <PsychEval>Completed</PsychEval>
                </TimelineInfo>";
    XmlDocument doc = new XmlDocument();
    doc.LoadXml(xml);
    var node = doc.SelectSingleNode("/TimelineInfo/Ambassador");
    Console.WriteLine(node.InnerText);
