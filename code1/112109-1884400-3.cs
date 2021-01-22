    namespace Wizardry
    {
        using System;
        public class WhiteWizard : IWizard
        {
            public IMagic GetMagic(string magicWord)
            {
                throw new NotImplementedException();
            }
        }
        public class BlackWizard : IWizard
        {
            public IMagic GetMagic(string magicWord)
            {
                throw new NotImplementedException();
            }
        }
    }
