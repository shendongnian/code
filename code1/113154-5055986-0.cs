    public static BindingBase CloneBinding(BindingBase bindingBase, object source)
    {
        var binding = bindingBase as Binding;
        if (binding != null)
        {
            var result = new Binding
                             {
                                 Source = source,
                                 AsyncState = binding.AsyncState,
                                 BindingGroupName = binding.BindingGroupName,
                                 BindsDirectlyToSource = binding.BindsDirectlyToSource,
                                 Converter = binding.Converter,
                                 ConverterCulture = binding.ConverterCulture,
                                 ConverterParameter = binding.ConverterCulture,
                                 //ElementName = binding.ElementName,
                                 FallbackValue = binding.FallbackValue,
                                 IsAsync = binding.IsAsync,
                                 Mode = binding.Mode,
                                 NotifyOnSourceUpdated = binding.NotifyOnSourceUpdated,
                                 NotifyOnTargetUpdated = binding.NotifyOnTargetUpdated,
                                 NotifyOnValidationError = binding.NotifyOnValidationError,
                                 Path = binding.Path,
                                 //RelativeSource = binding.RelativeSource,
                                 StringFormat = binding.StringFormat,
                                 TargetNullValue = binding.TargetNullValue,
                                 UpdateSourceExceptionFilter = binding.UpdateSourceExceptionFilter,
                                 UpdateSourceTrigger = binding.UpdateSourceTrigger,
                                 ValidatesOnDataErrors = binding.ValidatesOnDataErrors,
                                 ValidatesOnExceptions = binding.ValidatesOnExceptions,
                                 XPath = binding.XPath,
                             };
            foreach (var validationRule in binding.ValidationRules)
            {
                result.ValidationRules.Add(validationRule);
            }
            return result;
        }
        var multiBinding = bindingBase as MultiBinding;
        if (multiBinding != null)
        {
            var result = new MultiBinding
                             {
                                 BindingGroupName = multiBinding.BindingGroupName,
                                 Converter = multiBinding.Converter,
                                 ConverterCulture = multiBinding.ConverterCulture,
                                 ConverterParameter = multiBinding.ConverterParameter,
                                 FallbackValue = multiBinding.FallbackValue,
                                 Mode = multiBinding.Mode,
                                 NotifyOnSourceUpdated = multiBinding.NotifyOnSourceUpdated,
                                 NotifyOnTargetUpdated = multiBinding.NotifyOnTargetUpdated,
                                 NotifyOnValidationError = multiBinding.NotifyOnValidationError,
                                 StringFormat = multiBinding.StringFormat,
                                 TargetNullValue = multiBinding.TargetNullValue,
                                 UpdateSourceExceptionFilter = multiBinding.UpdateSourceExceptionFilter,
                                 UpdateSourceTrigger = multiBinding.UpdateSourceTrigger,
                                 ValidatesOnDataErrors = multiBinding.ValidatesOnDataErrors,
                                 ValidatesOnExceptions = multiBinding.ValidatesOnDataErrors,
                             };
            foreach (var validationRule in multiBinding.ValidationRules)
            {
                result.ValidationRules.Add(validationRule);
            }
            foreach (var childBinding in multiBinding.Bindings)
            {
                result.Bindings.Add(CloneBinding(childBinding, source));
            }
            return result;
        }
        var priorityBinding = bindingBase as PriorityBinding;
        if (priorityBinding != null)
        {
            var result = new PriorityBinding
                             {
                                 BindingGroupName = priorityBinding.BindingGroupName,
                                 FallbackValue = priorityBinding.FallbackValue,
                                 StringFormat = priorityBinding.StringFormat,
                                 TargetNullValue = priorityBinding.TargetNullValue,
                             };
            foreach (var childBinding in priorityBinding.Bindings)
            {
                result.Bindings.Add(CloneBinding(childBinding, source));
            }
            return result;
        }
        throw new NotSupportedException("Failed to clone binding");
    }
