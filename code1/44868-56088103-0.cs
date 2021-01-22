    public static class Extensions
    {
        public static IEnumerable<Control> GetAncestors(this Control control)
        {
            if (control == null)
                yield break;
            while ((control = control.Parent) != null)
                yield return control;
        }
    }
