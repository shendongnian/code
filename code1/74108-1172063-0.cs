    using System.Text.RegularExpressions;
...
            string line = "documents/jan/letter043.doc";
            string marker = Regex.Escape("/");
            string BeforeMarkerText = Regex.Match(line, "[^" + marker + "]+").Value;
            System.Diagnostics.Debug.WriteLine(BeforeMarkerText);
