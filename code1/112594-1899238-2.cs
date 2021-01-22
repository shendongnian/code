        private static bool SetAlignment(HorizontalAlignment value)
        {
            bool flag = true;
            using (RegistryKey registryKey = Registry.LocalMachine.CreateSubKey(REGISTRYKEY))
            {
                if (registryKey != null)
                {
                    try
                    {
                        registryKey.SetValue(ALIGNMENT_KEYNAME, value.ToString(), RegistryValueKind.String);
                    }
                    catch (Exception exception)
                    {
                        Logging.LogException(exception);
                        flag = false;
                    }
                }
            }
            return flag;
        }
