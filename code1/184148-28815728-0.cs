            Page.Validate(sValidationGroup);
            foreach (BaseValidator validator in Page.GetValidators(sValidationGroup))
            {
                if (!validator.IsValid)
                {
                    return false;
                }
            }
            return true;
        }
