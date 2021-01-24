    public class Formatter : OutputFormatter
    {
        public override bool CanWriteResult(OutputFormatterCanWriteContext context)
        {
            return context.HttpContext.Items["data"] is QData;
        }
        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
        {
            var incoming = context.HttpContext.Items["data"] as QData;
            .......
        }
    }
