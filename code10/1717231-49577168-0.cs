            private void Trust()
            {
                var cert = SelectedItem.Certificate;
                var store = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadWrite);
                if (store.Certificates.Find(X509FindType.FindByThumbprint, cert.Thumbprint, false).Count == 0)
                {
                    try
                    {
                        store.Add(cert);
                    }
                    catch (CryptographicException ex)
                    {
                        if (ex.HResult != NativeMethods.UserCancelled)
                        {
                            var dialog = (IManagementUIService)GetService(typeof(IManagementUIService));
                            dialog.ShowMessage($"An unexpected error happened. HResult is {ex.HResult}. Contact your system administrator.", Name,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
    
                        // add operation cancelled.
                    }
                }
    
                store.Close();
            }
