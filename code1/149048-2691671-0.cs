        foreach (IValidator cValidator in Page.GetValidators(null))
        {
            BaseValidator bv = (cValidator as BaseValidator);
            bv.CssClass = "Error";
            bv.Display = ValidatorDisplay.Dynamic;
            bv.ForeColor = System.Drawing.Color.Empty;
        }
