    public void copyRemoteFiles(string sourceFile, string destFile) {
        IntPtr admin_token = default(IntPtr);
        WindowsIdentity wid_current = WindowsIdentity.GetCurrent();
        WindowsIdentity wid_admin = null;
        WindowsImpersonationContext wic = null;
        
        try {
            if (LogonUser(sUserName, sDomainName, sPassword, 9, 0, admin_token) != 0) {
                wid_admin = new WindowsIdentity(admin_token);
                wic = wid_admin.Impersonate();
                if (System.IO.File.Exists(sourceFile)) {
                    System.IO.File.Copy(sourceFile, destFile, true);
                }
                else {
                    //Copy Failed
                    return;
                }
            }
            else {
                return;
            }
        }
        catch (System.Exception se) {
            int ret = Marshal.GetLastWin32Error();
            MessageBox.Show(ret.ToString(), "Error code: " + ret.ToString());
            MessageBox.Show(se.Message);
            if (wic != null) {
                wic.Undo();
            }
            return;
        }
        finally {
            if (wic != null) {
                wic.Undo();
            }
            
        }
    }
