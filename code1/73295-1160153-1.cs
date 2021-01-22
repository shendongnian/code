    public static IEnumerable<Control> FindAllControls(this Control control) {
        yield return control;
        foreach ( var child in control.Controls ) {
            foreach ( var all in child.FindAllControls() ) {
              yield return all;
            }
        }
    }
