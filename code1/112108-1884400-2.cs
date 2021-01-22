    namespace Wizardry
    {
        using System.ComponentModel.Composition;
        [Export(typeof(IWizardProvider))]
        [Name("White Wizard")]
        [Spells("booblah", "zoombar")]
        public class WhiteWizardProvider : IWizardProvider
        {
            public IWizard CreateWizard()
            {
                return new WhiteWizard();
            }
        }
        [Export(typeof(IWizardProvider))]
        [Name("White Wizard")]
        [Spells("zoogle", "xclondon")]
        public class BlackWizardProvider : IWizardProvider
        {
            public IWizard CreateWizard()
            {
                return new BlackWizard();
            }
        }
    }
