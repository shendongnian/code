    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
           
            string usr, grp;
            usr = txt_UserName.Text;
            grp = txt_GroupName.Text;
            add(usr, grp);
            groupBox2.Visible=true;
        }
        private void add(string usr, string grp)
        {
            bool flagUsr, flagGrp;
            try
            {
                DirectoryEntry AD = new DirectoryEntry("WinNT://" +Environment.MachineName + ",computer");
                DirectoryEntry group, user;
                group = AD.Children.Find(grp, "group");
                user = AD.Children.Find(usr, "user");
                if (user != null)
                {
                    label3.Text += "User Name Exists!!!";
                    flagUsr = true;
                }
                else
                {
                    label3.Text += "Sorry, No Such User Name Found!!!";
                    flagUsr = false;
                }
                if (group != null)
                {
                    label4.Text += "Group Exists!!!";
                    flagGrp = true;
                    
                }
                else
                {
                    label4.Text += "Sorry, Group Does Not Exists!!!";
                    flagGrp= false;
                }
                if(flagGrp == true && flagUsr == true)
                {
                    group.Invoke("Add", new object[] { user.Path.ToString() });
                    label5.Text += "Congratulations!!! User has been added to the group";
                }
                else
                {
                    label5.Text += "Error Happened!!! User could not be added to the group!!!";
                }
            }
            catch (Exception e)
            {
                label6.Text +=e.Message.ToString();
                label6.Visible= true;
            }
            }
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            normal();
        }
        private void normal()
        {
            txt_GroupName.Text="";
            txt_UserName.Text="";
            txt_UserName.Focus();
            groupBox2.Visible=false;
        }
        }
    }
