public static class ConfigExtensions
{
    public static void ConfigureAndValidate<T>(this IServiceCollection serviceCollection, Action<T> configureOptions) where T : class, new()
    {
        // Inspired by https://blog.bredvid.no/validating-configuration-in-asp-net-core-e9825bd15f10
        serviceCollection.Configure(configureOptions);
        using (var scope = serviceCollection.BuildServiceProvider().CreateScope())
        {
            var options = scope.ServiceProvider.GetRequiredService<IOptions<T>>();
            var optionsValue = options.Value;
            var configErrors = ValidationErrors(optionsValue).ToArray();
            if (!configErrors.Any())
            {
                return;
            }
            var aggregatedErrors = string.Join(",", configErrors);
            var count = configErrors.Length;
            var configType = typeof(T).FullName;
            throw new ApplicationException($"{configType} configuration has {count} error(s): {aggregatedErrors}");
        }
    }
    private static IEnumerable<string> ValidationErrors(object obj)
    {
        var context = new ValidationContext(obj, serviceProvider: null, items: null);
        var results = new List<ValidationResult>();
        Validator.TryValidateObject(obj, context, results, true);
        foreach (var validationResult in results)
        {
            yield return validationResult.ErrorMessage;
        }
    }
}
