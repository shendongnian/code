public class AWSTextFormatter : ITextFormatter
{
    public void Format(LogEvent logEvent, TextWriter output)
    {
        output.Write("Timestamp - {0} | Level - {1} | Message {2} {3}", logEvent.Timestamp, logEvent.Level, logEvent.MessageTemplate, output.NewLine);
        if (logEvent.Exception != null)
        {
            output.Write("Exception - {0}", logEvent.Exception);
        }
    }
}
Then insert in your code:
var outputTemplate = new AWSTextFormatter();
