    using AppFunc = Func<IDictionary<string, object>, Task>;
    //...
    public static class BranchAndMergeExtensions {
        public static IAppBuilder MapAndContinue(this IAppBuilder app, string pathMatch, Action<IAppBuilder> configuration) {
            return MapAndContinue(app, new PathString(pathMatch), configuration);
        }
        public static IAppBuilder MapAndContinue(this IAppBuilder app, PathString pathMatch, Action<IAppBuilder> configuration) {
            if (app == null) {
                throw new ArgumentNullException("app");
            }
            if (configuration == null) {
                throw new ArgumentNullException("configuration");
            }
            if (pathMatch.HasValue && pathMatch.Value.EndsWith("/", StringComparison.Ordinal)) {
                throw new ArgumentException("Path must not end with slash '/'", "pathMatch");
            }
            // put middleware in pipeline before creating branch
            var options = new MapOptions { PathMatch = pathMatch };
            var result = app.Use<MapAndContinueMiddleware>(options);
            // create branch and assign to options
            IAppBuilder branch = app.New();
            configuration(branch);
            options.Branch = (AppFunc)branch.Build(typeof(AppFunc));
            return result;
        }
    }
