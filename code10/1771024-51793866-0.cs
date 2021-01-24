      [TestMethod]
      public async Task PassValidateEmployeeConfigurationTest()
      {
            //ARRANGE
            const long employeeId = 200L;
            const int configurationTypeId = (int) Constants.Configuration.ConfigurationTypes.User;
            //need the IOC container 
            var unityContainer = new UnityContainer();
            //Mock ALL the dependencies (services and repositories)
            var ruleFacade = new Mock<IRuleFacade>();
            var employeeConfigMapRepo = new Mock<IEmployeeConfigurationMapRepo>();
            var ruleRepo = new Mock<IRuleRepo>();
            var ruleService = new Mock<IRuleService>();
            var configurationService = new Mock<IConfigurationService>();
            var employeeConfigurationService = new Mock<IEmployeeConfigurationService>();
            var organizationConfigurationService = new Mock<IOrganizationConfigurationService>();
            var facilityConfigurationService = new Mock<IFacilityConfigurationService>();
            var configurationSettingService = new Mock<IConfigurationSettingService>();
            // configure the dependencies so that the proper inputs are available
            configurationService.Setup(x => x.GetByConfigurationNameAsync(It.IsAny<string>()))
                .ReturnsAsync(GetConfigurations(true));
            employeeConfigMapRepo.Setup(x => x.GetAllByEmployeeIdAsync(It.IsAny<int>()))
                .ReturnsAsync(GetEmployeeConfigMaps(true));
            employeeConfigurationService.Setup(x => x.GetAllByEmployeeIdAsync(It.IsAny<long>()))
                .ReturnsAsync(GetEmployeeConfigMaps(true));
            ruleRepo.Setup(x => x.GetByConfigurationIdAsync(It.IsAny<int>()))
                .ReturnsAsync(GetRules(true));
            ruleService.Setup(x => x.GetConfigRulesByEmployeeIdAsync(It.IsAny<long>(), It.IsAny<string>()))
                .ReturnsAsync(GetRules(true));
            // help the IOC do its thing, map interfaces to Mocked objects
            unityContainer.RegisterInstance<IRuleService>(ruleService.Object);
            unityContainer.RegisterInstance<IRuleRepo>(ruleRepo.Object);
            unityContainer.RegisterInstance<IConfigurationService>(configurationService.Object);
            unityContainer.RegisterInstance<IEmployeeConfigurationService>(employeeConfigurationService.Object);
            unityContainer.RegisterInstance<IOrganizationConfigurationService>(organizationConfigurationService.Object);
            unityContainer.RegisterInstance<IFacilityConfigurationService>(facilityConfigurationService.Object);
            unityContainer.RegisterInstance<IConfigurationSettingService>(configurationSettingService.Object);
            unityContainer.RegisterInstance<IRuleFacade>(ruleFacade.Object);
            // thanks to all the mocking, the facade method ValidateEmployeeConfigurationAsync can now be tested properly
            var ruleHelper = unityContainer.Resolve<RuleFacade>();
            //ACT
            var result = await
                ruleHelper.ValidateEmployeeConfigurationAsync(employeeId, _testConfigName, configurationTypeId);
            //ASSERT
            Assert.IsNotNull(result);
            Assert.AreEqual(true, result.PassedValidation);
        } 
