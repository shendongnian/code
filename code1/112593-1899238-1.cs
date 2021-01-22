        private static HorizontalAlignment GetAlignment()
        {
            HorizontalAlignment alignmentValue = DEFAULT_ALIGNMENT;
            using (RegistryKey registryKey = Registry.LocalMachine.CreateSubKey(REGISTRYKEY))
            {
                if (registryKey != null)
                {
                    string tempAlignment = registryKey.GetValue(ALIGNMENT_KEYNAME, string.Empty).ToString();
                    if (!string.IsNullOrEmpty(tempAlignment))
                    {
                        try
                        {
                            alignmentValue = (HorizontalAlignment)Enum.Parse(typeof(HorizontalAlignment), tempAlignment, false);
                        }
                        catch (Exception exception)
                        {
                            alignmentValue = DEFAULT_ALIGNMENT;
                            Logging.LogException(exception);
                        }
                    }
                }
            }
            return alignmentValue;
        }
