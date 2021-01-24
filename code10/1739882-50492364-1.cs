    public static class Helpers
    {
        public static void ExecuteHelpUnderPoint(FrameworkElement parent, Point point)
        {
            var hittestctl = parent.InputHitTest(point) as FrameworkElement;
            var helpID = GetNearestDataContextHelpID(hittestctl);
            if (helpID != null)
            {
                ApplicationCommands.Help.Execute(helpID, hittestctl);
            }
        }
        public static IEnumerable<T> GetAncestorsOfType<T>(DependencyObject dobj) where T : DependencyObject
        {
            dobj = VisualTreeHelper.GetParent(dobj);
            while (dobj != null)
            {
                if (dobj is T t)
                    yield return t;
                dobj = VisualTreeHelper.GetParent(dobj);
            }
        }
        public static Object GetNearestDataContextHelpID(DependencyObject dobj)
        {
            var dataContexts = GetAncestorsOfType<FrameworkElement>(dobj)
                .Select(fe => fe.DataContext).Where(dc => dc != null);
            //  LINQ distinct probably doesn't affect order, but that's not guaranteed.
            //  https://stackoverflow.com/a/4734876/424129
            object prev = null;
            foreach (var dc in dataContexts)
            {
                if (dc != prev)
                {
                    var prop = dc.GetType().GetProperty("HelpId");
                    if (prop != null)
                    {
                        var value = prop.GetValue(dc);
                        if (value != null)
                        {
                            return value;
                        }
                    }
                    prev = dc;
                }
            }
            return null;
        }
    }
