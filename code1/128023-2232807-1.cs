    using System.Configuration;
    using System.Reflection;
    using System.Web.Security;
    
    namespace WebAdminViaWindows
    {
        internal static class Provider
        {
            private static readonly string assemblyFilePath = Assembly.GetExecutingAssembly().Location;
    
            static Provider()
            {
                Membership = CreateMembershipProvider();
                Role = CreateRoleProvider();
            }
    
            public static MembershipProvider Membership { get; private set; }
            public static RoleProvider Role { get; private set; }
    
            private static MembershipProvider CreateMembershipProvider()
            {
                var config = ConfigurationManager.OpenExeConfiguration(assemblyFilePath);
    
                var systemWebGroup = config.SectionGroups["system.web"];
                if (systemWebGroup == null)
                {
                    throw new ConfigurationErrorsException("system.web group not found in configuration");
                }
    
                var membershipSection = systemWebGroup.Sections["membership"];
                if (membershipSection == null)
                {
                    throw new ConfigurationErrorsException("membership section not found in system.web group");
                }
    
                var defaultProviderProperty = membershipSection.ElementInformation.Properties["defaultProvider"];
                if (defaultProviderProperty == null)
                {
                    throw new ConfigurationErrorsException("defaultProvider property not found in membership section");
                }
    
                var defaultProviderName = defaultProviderProperty.Value as string;
                if (defaultProviderName == null)
                {
                    throw new ConfigurationErrorsException("defaultProvider property is not a string value");
                }
    
                var providersProperty = membershipSection.ElementInformation.Properties["providers"];
                if (providersProperty == null)
                {
                    throw new ConfigurationErrorsException("providers property not found in membership section");
                }
    
                var providerCollection = providersProperty.Value as ProviderSettingsCollection;
                if (providerCollection == null)
                {
                    throw new ConfigurationErrorsException("providers property is not an instance of ProviderSettingsCollection");
                }
    
                ProviderSettings membershipProviderSettings = null;
    
                foreach (ProviderSettings providerSetting in providerCollection)
                {
                    if (providerSetting.Name == defaultProviderName)
                    {
                        membershipProviderSettings = providerSetting;
                    }
                }
    
                if (membershipProviderSettings == null)
                {
                    if (providerCollection.Count > 0)
                    {
                        membershipProviderSettings = providerCollection[0];
                    }
                    else
                    {
                        throw new ConfigurationErrorsException("No providers found in configuration");
                    }
                }
    
                var provider = new SqlMembershipProvider();
                provider.Initialize("MySqlMembershipProvider", membershipProviderSettings.Parameters);
                return provider;
            }
    
            private static RoleProvider CreateRoleProvider()
            {
                var config = ConfigurationManager.OpenExeConfiguration(assemblyFilePath);
    
                var systemWebGroup = config.SectionGroups["system.web"];
                if (systemWebGroup == null)
                {
                    throw new ConfigurationErrorsException("system.web group not found in configuration");
                }
    
                var roleManagerSection = systemWebGroup.Sections["roleManager"];
                if (roleManagerSection == null)
                {
                    throw new ConfigurationErrorsException("roleManager section not found in system.web group");
                }
    
                var defaultProviderProperty = roleManagerSection.ElementInformation.Properties["defaultProvider"];
                if (defaultProviderProperty == null)
                {
                    throw new ConfigurationErrorsException("defaultProvider property not found in roleManager section");
                }
    
                var defaultProviderName = defaultProviderProperty.Value as string;
                if (defaultProviderName == null)
                {
                    throw new ConfigurationErrorsException("defaultProvider property is not a string value");
                }
    
                var providersProperty = roleManagerSection.ElementInformation.Properties["providers"];
                if (providersProperty == null)
                {
                    throw new ConfigurationErrorsException("providers property not found in roleManagerSection section");
                }
    
                var providerCollection = providersProperty.Value as ProviderSettingsCollection;
                if (providerCollection == null)
                {
                    throw new ConfigurationErrorsException("providers property is not an instance of ProviderSettingsCollection");
                }
    
                ProviderSettings roleProviderSettings = null;
    
                foreach (ProviderSettings providerSetting in providerCollection)
                {
                    if (providerSetting.Name == defaultProviderName)
                    {
                        roleProviderSettings = providerSetting;
                    }
                }
    
                if (roleProviderSettings == null)
                {
                    if (providerCollection.Count > 0)
                    {
                        roleProviderSettings = providerCollection[0];
                    }
                    else
                    {
                        throw new ConfigurationErrorsException("No providers found in configuration");
                    }
                }
    
                var provider = new SqlRoleProvider();
                provider.Initialize("MySqlRoleManager", roleProviderSettings.Parameters);
                return provider;
            }
        }
    }
