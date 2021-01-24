    public static class MvcOptionsExtensions
    {
        public static void UseToUppercaseJsonInputFormatter(this MvcOptions opts)
        {
            if (opts.InputFormatters.FirstOrDefault(f => f is JsonInputFormatter && !(f is JsonPatchInputFormatter)) is JsonInputFormatter jsonInputFormatter)
            {
                var jsonInputFormatterIndex = opts.InputFormatters.IndexOf(jsonInputFormatter);
                opts.InputFormatters[jsonInputFormatterIndex] = new ToUppercaseJsonInputFormatter(jsonInputFormatter);
            }
        }
    }
