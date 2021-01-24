                RegistryKey SQMRegKey = Registry.LocalMachine.OpenSubKey("System\\CurrentControlSet\\Control\\WMI\\Autologger", true);
                //SQMRegKey.DeleteSubKey("SQMLogger");
                SQMRegKey.DeleteSubKeyTree("SQMLogger");
                SQMRegKey.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
