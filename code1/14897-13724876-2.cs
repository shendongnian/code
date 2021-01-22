    private void DumpError(Exception exception, Stack<String> context)
    {
        if (context.Any())
        {
            Trace.WriteLine(context.Pop());
            Trace.Indent();
            this.DumpError(exception, context);
            Trace.Unindent();
        }
        else
        {
            Trace.WriteLine(exception.Message);
        }
    }
