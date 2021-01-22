    namespace Wizardry
    {
        using System;
        using System.Collections.Generic;
        using System.ComponentModel.Composition;
        using System.Linq;
        public class UserWizardCreationService
        {
            [Import]
            private IEnumerable<Lazy<IWizardProvider, IWizardProviderMetadata>> WizardProviders { get; set; }
            public IWizard CreateWizard()
            {
                IWizard wizard = null;
                Lazy<IWizardProvider, IWizardProviderMetadata> lazyWizardProvider = null;
                IWizardProvider wizardProvider = null;
                // example 1: get a provider that can create a "White Wizard"
                lazyWizardProvider = WizardProviders.FirstOrDefault(provider => provider.Metadata.Name == "White Wizard");
                if (lazyWizardProvider != null)
                    wizardProvider = lazyWizardProvider.Value;
                // example 2: get a provider that can create a wizard that can cast the "booblah" spell
                lazyWizardProvider = WizardProviders.FirstOrDefault(provider => provider.Metadata.Spells.Contains("booblah"));
                if (lazyWizardProvider != null)
                    wizardProvider = lazyWizardProvider.Value;
                // finally, for whatever wizard provider we have, use it to create a wizard
                if (wizardProvider != null)
                    wizard = wizardProvider.CreateWizard();
                return wizard;
            }
        }
    }
