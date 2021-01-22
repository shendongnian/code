string sReg = @"&lt;body.*?&gt;((?&lt;Region&gt;\&lt;\!\-\-\s+\#Editable\s?\\$(?&lt;editable&gt;.+)\\$\s?\-\-\&gt;[^\&gt;]).*?)</body>";
string sNewReg = sReg1.Replace('$', '\"');            System.Diagnostics.Debug.WriteLine(string.Format("Regex: {0}", sNewReg))
Regex MyRegex = new Regex(sNewReg,
    RegexOptions.IgnoreCase
    | RegexOptions.CultureInvariant
    | RegexOptions.IgnorePatternWhitespace
    | RegexOptions.Compiled
    );
string sMg = "&lt;html&gt;&lt;head&gt;&lt;/head&gt;&lt;body&gt;&lt;!-- #Editable \\\"Body1\\\" --&gt;&lt;p&gt;etc etc&lt;/p&gt;&lt;!-- #Editable \\\"Extra\\\" --&gt;&lt;/body&gt;&lt;/html&gt;";
Match m = MyRegex.Match(sMg);
if (m.Success)
{
  System.Diagnostics.Debug.WriteLine(string.Format("{0}", m.Groups["editable"].Value));
}
