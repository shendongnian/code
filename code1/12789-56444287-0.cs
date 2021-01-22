public ViewEngineResult FindView(ActionContext context, string viewName, bool isMainPage)
        {
            var controllerName = context.GetNormalizedRouteValue(CONTROLLER_KEY);
            var areaName = context.GetNormalizedRouteValue(AREA_KEY);
            var checkedLocations = new List<string>();
            foreach (var location in _options.ViewLocationFormats)
            {
                var view = string.Format(location, viewName, controllerName);
                if (File.Exists(view))
                {
                    return ViewEngineResult.Found("Default", new View(view, _ViewRendering));
                }
                checkedLocations.Add(view);
            }
            return ViewEngineResult.NotFound(viewName, checkedLocations);
        }
Example: https://github.com/AspNetMonsters/pugzor
