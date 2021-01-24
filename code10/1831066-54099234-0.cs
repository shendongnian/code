            List<string> validationProperties = new List<string> { "Years"};
            bool isValid = true;
            foreach (PropertyInfo propertyInfo in model.GetType().GetProperties())
            {
                if (validationProperties .Contains(propertyInfo.Name))
                    isValid = ModelState.IsValidField(propertyInfo.Name) && isValid;
            }
            if (isValid)
            {
                // do stuff here
            }
