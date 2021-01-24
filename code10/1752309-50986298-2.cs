    private static IEnumerable<Control> GetAll(Control control) {
      var controls = control.Controls.OfType<Control>();
      return controls
        .SelectMany(ctrl => GetAll(ctrl))
        .Concat(controls);
    }
    ...
    int sum = GetAll(this)
      .OfType<TextBox>()
      .Where(box => string.Equals("ExpenseField", box.Tag as String))
      .Select(box => int.TryParse(box.Text, out var v) ? v : 0)
      .Sum(); 
    this.TotalExpenseLbl.Text = sum.ToString();
    this.TotalMonthlyExpenses.Text = sum.ToString();
