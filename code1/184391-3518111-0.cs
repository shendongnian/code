    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine(Transform(XDocument.Parse(xml)));
        Console.ReadLine();
    }
    static string Transform(XDocument doc)
    {
        var topElem = doc.Root;
        var fsmName = topElem.Attribute("name").Value;
        var sb = new StringBuilder();
        foreach (var state in topElem.Elements("state"))
        {
            var currentStateName = state.Attribute("name").Value;
            sb.AppendLine(string.Format("public class {0} : {1}States", currentStateName, fsmName));
            sb.AppendLine("{");
            sb.AppendLine(string.Format("  public {0}()", currentStateName));
            sb.AppendLine("  {");
            sb.AppendLine(string.Format(@"      Console.WriteLine(""In {0}State"");", currentStateName));
            sb.AppendLine("  }");
            foreach (var @event in topElem.Elements("event"))
            {
                var eventName = @event.Attribute("name").Value;
                sb.AppendLine(string.Format("  public override void {0}(MediaPlayer player)", eventName));
                sb.AppendLine("  {");
                bool any = false;
                foreach (var transition in topElem.Elements("transition"))
                {
                    if (transition.Attribute("source").Value == currentStateName && transition.Element("trigger").Attribute("name").Value == eventName)
                    {
                        sb.AppendLine("        implement guard/action");
                        any = true;
                        break;
                    }
                }
                if (!any)
                    sb.AppendLine("        throw new NotImplementedException();");
                sb.AppendLine("  }");
            }
            sb.AppendLine("}");
        }
        return sb.ToString();
    }
