    private RegularExpressionValidator GetRegValidator(string itemId, string regExp)
        {
            RegularExpressionValidator _regVal = new RegularExpressionValidator();
            _regVal.ControlToValidate = itemId;
            _regVal.ValidationExpression = regExp;
            _regVal.ErrorMessage ="PropertyRegexDoesNotMatches";
            _regVal.Text = "*";
            _regVal.SetFocusOnError = true;
            _regVal.EnableClientScript = true;
            _regVal.ID = string.Format("{0}Validator", itemId);
            return _regVal;
        }
