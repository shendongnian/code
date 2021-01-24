    public abstract class BaseValidator<T> : AbstractValidator<T>
    {
        private readonly ValidationEntitySettingServices _validationEntitySettingService;
        public BaseValidator(ValidationEntitySettingServices validationEntitySettingService)
        {
            _validationEntitySettingService = validationEntitySettingService;
        }
        private string ViewModelName
        {
            get { return GetType().Name.Replace("Validator", string.Empty); }
        }
        public bool IsPropertyRequired(string propertyName)
        {
            var validationSetting = _validationEntitySettingService.GetIncluding(ViewModelName);
            if (validationSetting != null)
            {
                return validationSetting.ValidationEntityProperties.Any(p => p.PropertyName.Equals(propertyName) && p.IsRequired);
            }
            else
                return false;
        }
        protected void AddEmptyRuleFor<TProperty>(Expression<Func<T, TProperty>> expression, string message)
        {
            RuleFor(expression).NotEmpty().When(x => IsPropertyRequired(((MemberExpression)expression.Body).Name)).WithMessage(message);
        }
    }
