        public bool ToggleValidate()
        {
            uneCalcValue.CausesValidation = !uneCalcValue.CausesValidation;
            txtDescription.CausesValidation = !txtDescription.CausesValidation;
            return txtDescription.CausesValidation;
        }
