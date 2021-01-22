    public static bool ValidateServerCertificate(object sender,X509Certificate certificate,X509Chain chain,SslPolicyErrors sslPolicyErrors)
    {
        if (sslPolicyErrors == SslPolicyErrors.None)
            return true;
        else
        {
            if (System.Windows.Forms.MessageBox.Show("The server certificate is not valid.\nAccept?", "Certificate Validation", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                return true;
            else
                return false;
        }
    }
