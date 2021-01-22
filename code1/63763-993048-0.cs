            ServiceSecurityContext current = ServiceSecurityContext.Current;
            if (!current.IsAnonymous)
            {
                if (current.WindowsIdentity != null)
                {
                    string userName = current.WindowsIdentity.Name;
                }
            }
