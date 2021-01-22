        public static IEnumerable<string> GetAdsiProviders()
        {
            var providers = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\ADs\Providers");
            if (null == providers) yield break;
            foreach (var name in providers.GetSubKeyNames())
            {
                yield return name + ":";
            }
        }
