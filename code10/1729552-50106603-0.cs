    public static IApplicationBuilder UseMyService(this IApplicationBuilder builder, Action<CustomOptions> options)
    {
        var defaultOptions = new CustomOptions();
        // you can initialize defaultOptions here with default vaues
        // then invoke the delegate to override specific values
        options?.Invoke(defaultOptions);
    }
