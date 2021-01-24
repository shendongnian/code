    foreach (var bla in pnlLoanProcess.Controls.OfType<BookLoanActions>())
    {
        foreach (var rptr in bla.Controls.OfType<Repeater>())
        {
            isChecked = rtpr.Controls.OfType<CheckBox>().Any(c => c.IsChecked));
        }
    }
