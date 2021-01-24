        private string GetRequestsRoute(string requestsRoot)
        {
            if (_requestsPath != null)
                return _requestsPath;
            var relatedControllerAttribute = GetType().GetCustomAttribute<RelatedControllerAttribute>();
            if (relatedControllerAttribute  == null)
                throw new NotSupportedException($"The {GetType().Name} must have a ${typeof(RelatedControllerAttribute).Name}");
            var apiExplorerSettingsAttribute = relatedControllerAttribute.RelatedControllerType.GetCustomAttribute<ApiExplorerSettingsAttribute>();
            if (apiExplorerSettingsAttribute == null)
                throw new NotSupportedException($"The {relatedControllerAttribute.RelatedControllerType.Name} must have a ${typeof(ApiExplorerSettingsAttribute).Name}");
            var routeAttribute = relatedControllerAttribute.RelatedControllerType.GetCustomAttribute<RouteAttribute>();
            if (routeAttribute == null)
                throw new NotSupportedException($"The {relatedControllerAttribute.RelatedControllerType.Name} must have a ${typeof(RouteAttribute).Name}");
            return _requestsPath = routeAttribute.Template
                .Replace(
                    "[controller]",
                    relatedControllerAttribute.RelatedControllerType.Name.Replace("Controller", ""))
                .Replace(
                    "{version:apiVersion}",
                    apiExplorerSettingsAttribute.GroupName.Replace("v", ""))
                .ToLowerInvariant();
        }
