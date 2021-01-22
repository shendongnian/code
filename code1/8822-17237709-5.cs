    public static class ScreenObjectExtensions
    {
        public static IEnumerable<IContentItemProxy> FindControls(this IScreenObject screen)
        {
            var model = screen.Details.GetModel();
            return model.GetChildItems()
                .SelectManyRecursive(c => c.GetChildItems())
                .OfType<IContentItemDefinition>()
                .Select(c => screen.FindControl(c.Name));
        }
    }
