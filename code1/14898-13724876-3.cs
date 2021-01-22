    private void DumpError(Exception exception, Stack<String> context)
    {
        if (context.Any())
        {
            var popped = context.Pop();
            Trace.WriteLine(popped);
            Trace.Indent();
            this.DumpError(exception, context);
            Trace.Unindent();
        }
        else
        {
            Trace.WriteLine(exception.Message);
        }
    }
