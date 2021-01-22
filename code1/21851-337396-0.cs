            Process p = new Process();
            p.StartInfo.FileName = textFilename.Text;
            p.StartInfo.Arguments = textArgument.Text;
            p.StartInfo.UserName = textUsername.Text;
            p.StartInfo.Domain = textDomain.Text;
            p.StartInfo.Password = securePassword.SecureText;
                
            p.StartInfo.LoadUserProfile = true;
            p.StartInfo.UseShellExecute = false;
            try {
                p.Start();
            } catch (Win32Exception ex) {
                MessageBox.Show("Error:\r\n" + ex.Message);
            }
