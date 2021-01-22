    ManagementObjectSearcher Encryption = new ManagementObjectSearcher(@"root\cimv2\Security\MicrosoftVolumeEncryption", "SELECT * FROM Win32_EncryptableVolume");
            foreach (ManagementObject QueryObj in Encryption.Get())
            {
                string EncryptionStatus = QueryObj.GetPropertyValue("ProtectionStatus").ToString();
                if (EncryptionStatus == "0")
                {
                    EncryptionDialog.Text = "Unencrypted";
                }
                else if (EncryptionStatus == "1")
                {
                    EncryptionDialog.Text = "Encrypted - SysPrep will not complete";
                }
                else if (EncryptionStatus == "2")
                {
                    EncryptionDialog.Text = "Cannot Determine Encryption";
                }
            }
