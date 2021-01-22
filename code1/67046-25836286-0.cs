        private bool IsJitOptimizerDisabled(Assembly assembly)
        {
            return assembly.GetCustomAttributes(typeof (DebuggableAttribute), false)
                .Select(customAttribute => (DebuggableAttribute) customAttribute)
                .Any(attribute => attribute.IsJITOptimizerDisabled);
        }
