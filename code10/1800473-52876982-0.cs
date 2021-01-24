    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using FluentValidation.Internal;
    using FluentValidation.TestHelper;
    using FluentValidation.Validators;
    
    namespace YourTestExtensionsNamespace
    {
        public static class CustomValidationExtensions
        {
            public static void ShouldHaveChildValidatorCustom<T, TProperty>(this IValidator<T> validator, Expression<Func<T, TProperty>> expression, Type childValidatorType)
            {
                var descriptor = validator.CreateDescriptor();
                var expressionMemberName = expression.GetMember()?.Name;
    
                if (expressionMemberName == null && !expression.IsParameterExpression())
                    throw new NotSupportedException("ShouldHaveChildValidator can only be used for simple property expressions. It cannot be used for model-level rules or rules that contain anything other than a property reference.");
    
                var matchingValidators = expression.IsParameterExpression() ? GetModelLevelValidators(descriptor) : descriptor.GetValidatorsForMember(expressionMemberName).ToArray();
    
                matchingValidators = matchingValidators.Concat(GetDependentRules(expressionMemberName, expression, descriptor)).ToArray();
    
                var childValidatorTypes = matchingValidators
                    .OfType<IChildValidatorAdaptor>()
                    .Select(x => x.ValidatorType);
    
                //get also the validator types for the child IDelegatingValidators
                var delegatingValidatorTypes = matchingValidators
                    .OfType<IDelegatingValidator>()
                    .Where(x => x.InnerValidator is IChildValidatorAdaptor)
                    .Select(x => (IChildValidatorAdaptor)x.InnerValidator)
                    .Select(x => x.ValidatorType);
    
                childValidatorTypes = childValidatorTypes.Concat(delegatingValidatorTypes);
    
                var validatorTypes = childValidatorTypes as Type[] ?? childValidatorTypes.ToArray();
                if (validatorTypes.All(x => !childValidatorType.GetTypeInfo().IsAssignableFrom(x.GetTypeInfo())))
                {
                    var childValidatorNames = validatorTypes.Any() ? string.Join(", ", validatorTypes.Select(x => x.Name)) : "none";
                    throw new ValidationTestException(string.Format("Expected property '{0}' to have a child validator of type '{1}.'. Instead found '{2}'", expressionMemberName, childValidatorType.Name, childValidatorNames));
                }
            }
    
            private static IPropertyValidator[] GetModelLevelValidators(IValidatorDescriptor descriptor)
            {
                var rules = descriptor.GetRulesForMember(null).OfType<PropertyRule>();
                return rules.Where(x => x.Expression.IsParameterExpression()).SelectMany(x => x.Validators)
                    .ToArray();
            }
    
            private static IEnumerable<IPropertyValidator> GetDependentRules<T, TProperty>(string expressionMemberName, Expression<Func<T, TProperty>> expression, IValidatorDescriptor descriptor)
            {
                var member = expression.IsParameterExpression() ? null : expressionMemberName;
                var rules = descriptor.GetRulesForMember(member).OfType<PropertyRule>().SelectMany(x => x.DependentRules)
                    .SelectMany(x => x.Validators);
    
                return rules;
            }
        }
    }
