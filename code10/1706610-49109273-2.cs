    public abstract class BaseValidator<T> : AbstractValidator<T>
    {
        private readonly ValidationEntitySettingServices _validationEntitySettingService;
        public BaseValidator(ValidationEntitySettingServices validationEntitySettingService)
        {
            _validationEntitySettingService = validationEntitySettingService;
            AutoApplyEmptyRules();
        }
        private string ViewModelName
        {
            get { return GetType().Name.Replace("Validator", string.Empty); }
        }
        // no longer needed
        //public bool IsPropertyRequired(string propertyName)
        //{
        //    var validationSetting = _validationEntitySettingService.GetIncluding(ViewModelName);
        //    if (validationSetting != null)
        //    {
        //        return validationSetting.ValidationEntityProperties.Any(p => p.PropertyName.Equals(propertyName) && p.IsRequired);
        //    }
        //    else
        //        return false;
        //}
        protected void AddEmptyRuleFor<TProperty>(Expression<Func<T, TProperty>> expression, string message)
        {
            //RuleFor(expression).NotEmpty().When(x => IsPropertyRequired(((MemberExpression)expression.Body).Name)).WithMessage(message);
            RuleFor(expression).NotEmpty().WithMessage(message);
        }
        private void AddEmptyRuleForProperty(PropertyInfo property)
        {
            MethodInfo methodInfo = GetType().GetMethod("AddEmptyRuleFor");
            Type[] argumentTypes = new Type[] { typeof(T), property.PropertyType };
            MethodInfo genericMethod = methodInfo.MakeGenericMethod(argumentTypes);
            object propertyExpression = ExpressionHelper.CreateMemberExpressionForProperty<T>(property);
            genericMethod.Invoke(this, new object[] { propertyExpression, $"{propertyInfo.Name} is a required field!" });
        }
        private PropertyInfo[] GetRequiredProperties()
        {
            var validationSetting = _validationEntitySettingService.GetIncluding(ViewModelName);
            if (validationSetting != null)
            {
                return validationSetting.ValidationEntityProperties.Where(p => p.IsRequired);
            }
            else
                return null;
        }
        private void AutoApplyEmptyRules()
        {
            PropertyInfo[] properties = GetRequiredProperties();
            if (properties == null)
                return;
            foreach (PropertyInfo propertyInfo in properties)
            {
                AddEmptyRuleForProperty(property);
            }
        }
    }
