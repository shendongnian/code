    public static IEnumerable<Control> GetControls(Control form) {
        foreach (Control childControl in form.Controls) {   // Recurse child controls.
            foreach (Control grandChild in GetControls(childControl)) {
                yield return grandChild;
            }
            yield return childControl;
        }
    }
