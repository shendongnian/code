    string test = @"Steps from the drive lead to a terrace with a stone balustrade and open views.  Front door and double glazed side window lead to the: [PHOTOA]This is text for PhotoA as WAITPHOTO code is followed.[WAITPHOTO]SITTING ROOM: 5.11m x 4.61m. Double glazed patio doors to front     terrace, with open views across Babbacombe. Double glazed window. Television aerial point. One screened radiator. One double radiator. [PHOTOB]This text is NOT for PhotoB as WAITPHOTO code is not followed.Steps from the drive lead to a terrace with a stone balustrade and open views.  Front door and double glazed side window lead to the: [PHOTOC]This is text for PhotoC as WAITPHOTO code is followed.[WAITPHOTO]";
    string regex = @"(\[PHOTO\w+\])([^\[]+)\[WAITPHOTO\]";
    System.Text.RegularExpressions.MatchCollection mc = System.Text.RegularExpressions.Regex.Matches(test, regex);
    foreach (System.Text.RegularExpressions.Match m in mc)
    {
        System.Console.WriteLine(m.Value);
        System.Console.WriteLine("This is the photo name: " + m.Groups[1].Value);
        System.Console.WriteLine("This is the photo text: " + m.Groups[2].Value);
    }
