        public string this[string property] {
            get { return Validate(property); }
        }
        public string Error { get; }
        protected virtual string Validate(string property) {
            var propertyInfo = this.GetType().GetProperty(property);
            var results = new List<ValidationResult>();
            var result = Validator.TryValidateProperty(
                                      propertyInfo.GetValue(this, null),
                                      new ValidationContext(this, null, null) {
                                          MemberName = property
                                      },
                                      results);
            if (!result) {
                var validationResult = results.First();
                return validationResult.ErrorMessage;
            }
            return string.Empty;
        }
