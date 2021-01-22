    public class Assembly
    {
        public static string GetTitle (string fileFullName) {
            var contents = File.ReadAllText (fileFullName); //may raise exception if file doesn't exist
            
            //regex string is: AssemblyTitle\x20*\(\x20*"(?<Title>.*)"\x20*\)
            //loading from settings because it is annoying to type it in editor
            var reg = new Regex (Settings.Default.Expression);
            var match = reg.Match (contents);
            var titleGroup = match.Groups["Title"];
            return (match.Success && titleGroup.Success) ? titleGroup.Value : String.Empty;
        }
    }
