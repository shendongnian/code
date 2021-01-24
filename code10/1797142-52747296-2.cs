        public static TProperty GetStepObject<TProperty>(this IWizardTransaction wizardTransaction)
            where TProperty : class
        {
            var properties = wizardTransaction.GetType().GetProperties()
                    .Where(x => x.GetCustomAttributes(typeof(StepAttribute), true).Any());
            PropertyInfo @object = properties.FirstOrDefault(x => 
                        (x.GetCustomAttributes(typeof(StepAttribute), true).SingleOrDefault()
                                    as StepAttribute).Step == StepEnum.CurrentStep);
            return @object.GetValue(wizardTransaction) as TProperty;
        }
