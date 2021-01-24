    internal class CustomFieldFormValueProvider : IValueProvider
    {
        private static readonly Regex AliasedFieldValueRegex = new Regex("(?<prefix>.*)(?<fieldNameAlias>\\%.*\\%)$");
        private readonly KeyValuePair<string, string>[] _customFields;
        private readonly IRequestCustomFieldResolver _resolver;
        private readonly ILogger _logger;
        public CustomFieldFormValueProvider(IRequestCustomFieldResolver resolver, KeyValuePair<string, string>[] customFields) {
            _resolver = resolver;
            _customFields = customFields;
            _logger = Log.ForContext(typeof(CustomFieldFormValueProvider));
        }
        public bool ContainsPrefix(string prefix) {
            return AliasedFieldValueRegex.IsMatch(prefix);
        }
        public ValueProviderResult GetValue(string key) {
            var match = AliasedFieldValueRegex.Match(key);
            if (match.Success) {
                var prefix = match.Groups["prefix"].Value;
                var fieldNameAlias = match.Groups["fieldNameAlias"].Value;
                // Unfortunately, IValueProvider::GetValue does not have an async variant :(
                var customFieldNumber = Task.Run(() => _resolver.Resolve(fieldNameAlias)).Result;
                var convertedKey = ConvertKey(prefix, customFieldNumber);
                string customFieldValue = null;
                try {
                    customFieldValue = _customFields.Single(pair => pair.Key.Equals(convertedKey, StringComparison.OrdinalIgnoreCase)).Value;
                } catch (InvalidOperationException) {
                    _logger.Warning("Could not find a value for '{FieldNameAlias}' - (custom field #{CustomFieldNumber} - assuming null", fieldNameAlias, customFieldNumber);
                }
                return new ValueProviderResult(new StringValues(customFieldValue));
            }
            return ValueProviderResult.None;
        }
        private string ConvertKey(string prefix, int customFieldNumber) {
            var path = prefix.Split('.')
                             .Where(part => !string.IsNullOrWhiteSpace(part))
                             .Concat(new[] {
                                 "fields",
                                 customFieldNumber.ToString()
                             })
                             .ToArray();
            return path[0] + string.Join("", path.Skip(1).Select(part => $"[{part}]"));
        }
    }
    public class CustomFieldFormValueProviderFactory : IValueProviderFactory
    {
        private static readonly Regex
            CustomFieldRegex = new Regex(".*[\\[]]?fields[\\]]?[\\[]([0-9]+)[\\]]$");
        public Task CreateValueProviderAsync(ValueProviderFactoryContext context) {
            // Get the key/value pairs from the form which look like our custom fields
            var customFields = context.ActionContext.HttpContext.Request.Form.Where(pair => CustomFieldRegex.IsMatch(pair.Key))
                                      .Select(pair => new KeyValuePair<string, string>(pair.Key, pair.Value.First()))
                                      .ToArray();
            // Pull out the service we need
            if (!(context.ActionContext.HttpContext.RequestServices.GetService(typeof(IRequestCustomFieldResolver)) is IRequestCustomFieldResolver resolver)) {
                throw new InvalidOperationException($"No service of type {typeof(IRequestCustomFieldResolver).Name} available");
            }
            context.ValueProviders.Insert(0, new CustomFieldFormValueProvider(resolver, customFields));
            return Task.CompletedTask;
        }
    }
