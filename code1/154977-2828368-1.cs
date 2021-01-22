    public IEnumerable<Control> GetAllControls(Control root) {
      foreach (Control control in root.Controls) {
        foreach (Control child in GetAllControls(control)) {
          yield return child;
        }
      }
      yield return root;
    }
