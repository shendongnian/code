    namespace Wizardry
    {
        using System.Collections.Generic;
        public interface IWizardProvider
        {
            IWizard CreateWizard();
        }
        public interface IWizard
        {
            IMagic GetMagic(string magicWord);
        }
        public interface IWizardProviderMetadata
        {
            string Name { get; }
            IEnumerable<string> Spells { get; }
        }
    }
