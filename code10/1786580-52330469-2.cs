     using System.Linq;
     using System.Text.RegularExpressions;
     ...
     string source = @"{X=113,Y=171}{X=160,Y=171}{X=160,Y=51}{X=113,Y=51}";
     // We assume each coordinate being an integer value 
     Regex pattern = new Regex(
       @"\{\s*X\s*=\s*(?<x>-?[0-9]+)\s*\,\s*Y\s*=\s*(?<y>-?[0-9]+)\s*\}",
        RegexOptions.IgnoreCase);
     // Let's take 4 top matches
     var data = pattern
      .Matches(source)
      .OfType<Match>()
      .Select(match => new {
        x = match.Groups["x"].Value,
        y = match.Groups["y"].Value,
      })
      .Take(4)
      .ToArray();
    if (data.Length == 4) {
      leftTextBox.Text   = data[3].x;
      topTextBox.Text    = data[3].y;
      rightTextBox.Text  = data[1].x; 
      bottomTextBox.Text = data[1].y; 
    }
