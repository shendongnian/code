    public class ToUppercaseJsonInputFormatter : TextInputFormatter
    {
        private readonly JsonInputFormatter _jsonInputFormatter;
        public ToUppercaseJsonInputFormatter(JsonInputFormatter jsonInputFormatter)
        {
            _jsonInputFormatter = jsonInputFormatter;
            foreach (var supportedEncoding in _jsonInputFormatter.SupportedEncodings)
                SupportedEncodings.Add(supportedEncoding);
            foreach (var supportedMediaType in _jsonInputFormatter.SupportedMediaTypes)
               SupportedMediaTypes.Add(supportedMediaType);
        }
        public override Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            var result = _jsonInputFormatter.ReadRequestBodyAsync(context, encoding);
            foreach (var property in context.ModelType.GetProperties().Where(p => p.PropertyType.IsAssignableFrom(typeof(string))
                && p.CustomAttributes.Any(a => a.AttributeType.IsAssignableFrom(typeof(ToUppercaseAttribute)))))
            {
                var value = (string)property.GetValue(result.Result.Model);
                property.SetValue(result.Result.Model, value.ToUpper());
            }
            return result;
        }
    }
