        private void DoSomething()
        {
            Contact contact = new Contact { FirstName = "Armin", LastName = "Zia", Birthday = new DateTime(1988, 04, 20) };
            ValidationContext context = new ValidationContext(contact, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();
            if (!Validator.TryValidateObject(contact, context, errors,true))
            {
                foreach (ValidationResult result in errors)
                    MessageBox.Show(result.ErrorMessage);
            }
            else
                MessageBox.Show("Validated");
        }
