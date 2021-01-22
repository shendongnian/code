            Environment.SharedEngineProvider = new NHibernateSharedEngineProvider();
            var fluentConfiguration = new FluentConfiguration();
            fluentConfiguration
                .SetMessageInterpolator<CustomMessageInterpolator>()
                .SetDefaultValidatorMode(ValidatorMode.OverrideAttributeWithExternal)
                .IntegrateWithNHibernate
                .ApplyingDDLConstraints()
                .And
                .RegisteringListeners();
            var validatorEngine = Environment.SharedEngineProvider.GetEngine();
            validatorEngine.Configure(fluentConfiguration);
            configuration.Initialize(validatorEngine);
