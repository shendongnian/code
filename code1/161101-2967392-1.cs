    var xml = @"<TimelineInfo>
                    <PreTrialEd>Not Started</PreTrialEd>
                    <Ambassador>Problem</Ambassador>
                    <PsychEval>Completed</PsychEval>
                </TimelineInfo>";
    var root = XElement.Parse(xml);
    string ambassador = (string)root.Element("Ambassador");
    Console.WriteLine(ambassador);
