    private static bool ReadDouble(Control control, bool allowEmpty, out double value) {
      if (allowEmpty && string.IsNullOrWhiteSpace(control.Text)) {
        value = 0.0;
        return true;
      }
      bool result = double.TryParse(control.Text, out value);
      if (!result) {
        if (control.CanFocus)
          control.Focus();
        MessageBox.Show("Invalid value; floating point value expected", 
                         Application.ProductName, 
                         MessageBoxButtons.OK, 
                         MessageBoxIcon.Warning);
      }
      return result;
    }
