        public enum Provider
        {
            A,
            B
        }
        private void CreateInstanceForProvider(Provider provider)
        {
            ProviderWrapper provider = null;
        
            switch (provider)
            {
                case Provider.A:
                    provider = new ProviderWrapper(FactorySingleton.Instance.CreateInstanceA("A"));
                    break;
                case Provider.B:
                    provider = new ProviderWrapper(FactorySingleton.Instance.CreateInstanceB("B"));
                    break;
            }
        
            if (provider == null)
            {
                ShowProviderNotInstanciatedMessage();
                return;
            }
        
            provider.SetOwner(Handle.ToInt32());
            lbl_Text.Text = provider.GetVersion();
        }
        public class ProviderWrapper
        {
            private readonly object _original;
            public ProviderWrapper(object original)
            {
                _original = original;
            }
            public void SetOwner(int value)
            {
                _original.GetType().GetProperty("Owner").SetValue(_original, value, null);
            }
            public string GetVersion()
            {
                return (String)_original.GetType().GetProperty("Owner").GetValue(_original, null);
            }
        }
