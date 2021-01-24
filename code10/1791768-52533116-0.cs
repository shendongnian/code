    public partial class Reg_Form : Form
        {
    
            private string Reg_path = "Software\\MySampleProgram";
            private string Reg_key = "Expire";
            public Reg_Form()
            {
                InitializeComponent();
    
                check_expire_date();
            }
    
            private void check_expire_date()
            {
                bool exists_key = check_reg();
                if (!exists_key)
                {
                    //first use, so we need to write expire date
                    bool is_write = write_reg();
                    if (!is_write)
                    {
                        MessageBox.Show("Run program as administrator and try again.");
                        this.Close();
                    }
                }
                var dt = read_reg_val();
                if (dt != null)
                {
                    DateTime current_date = DateTime.UtcNow;
                    DateTime reg_date = DateTime.UtcNow;
    
                    DateTime.TryParse(dt, out reg_date);
    
                    var res = (current_date - reg_date).TotalDays;
                    if (res < 7)
                    {
                        Main_Form frm = new Main_Form();
                        this.Hide();
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Please connect to internet for extend time !");
                        //do any other work.....
                    }
                }
                else
                {
                    MessageBox.Show("Error, try again !");
                    this.Close();
                }
            }
            private bool write_reg()
            {
                try
                {
                    Microsoft.Win32.RegistryKey key;
                    key = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(Reg_path);
                    key.SetValue(Reg_key, DateTime.UtcNow.ToShortDateString());
                    key.Close();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            private bool check_reg()
            {
                try
                {
                    RegistryKey key = Registry.LocalMachine.OpenSubKey(Reg_path);
                    if (key != null)
                    {
                        Object o = key.GetValue(Reg_key);
                        if (o != null)
                        {
                            return true;
                        }
                    }
                }
                catch
                {
                    return false;
                }
                return false;
            }
            private string read_reg_val()
            {
                try
                {
                    RegistryKey key = Registry.LocalMachine.OpenSubKey(Reg_path);
                    if (key != null)
                    {
                        Object o = key.GetValue(Reg_key);
                        if (o != null)
                        {
                            string res = o as String;
                            DateTime dt = DateTime.Now;
                            bool ok_date = DateTime.TryParse(res, out dt);
                            if (ok_date)
                            {
                                return res;
                            }
                            else
                            {
                                //changed value by user or hacked !
                                DateTime today = DateTime.UtcNow;
                                DateTime sevenDaysEarlier = today.AddDays(-8);
                                return sevenDaysEarlier.ToShortDateString();
                            }
                        }
                    }
                }
                catch
                {
                    return null;
                }
                return null;
            }
        }
