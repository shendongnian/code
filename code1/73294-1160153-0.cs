    public IEnumerable<Control> FindAllControls(this Control control) {
        yield return this;
        foreach ( var child in control.Controls ) {
            foreach ( var all in child.FindAllControls() ) {
              yield return all;
            }
        }
    }
