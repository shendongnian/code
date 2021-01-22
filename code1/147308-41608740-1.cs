        public static string ReplaceNamedGroup(this Regex regex, string input, string namedGroup, string value)
        {
            var replacement = Regex.Replace(regex.ToString(), 
                @"((?<GroupPrefix>\(\?)\<(?<GroupName>\w*)\>(?<Eval>.[^\)]+)(?<GroupPostfix>\)))", 
                @"${${GroupName}}").TrimStart('^').TrimEnd('$');
            replacement = replacement.Replace("${" + namedGroup + "}", value);
            return Regex.Replace(input, regex.ToString(), replacement);
        }
