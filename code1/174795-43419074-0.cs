    using RDPCOMAPILib;
    using System;
    using System.Windows.Forms;
    
    namespace screenSharingAttempt
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            RDPSession x = new RDPSession(); 
            private void Incoming(object Guest)
            {
                IRDPSRAPIAttendee MyGuest = (IRDPSRAPIAttendee)Guest; 
                MyGuest.ControlLevel = CTRL_LEVEL.CTRL_LEVEL_INTERACTIVE;
            }
    
    
            //access to COM/firewall will prompt 
            private void button1_Click(object sender, EventArgs e)
            {
                x.OnAttendeeConnected += Incoming;
                x.Open();
            }
    
            //connect
            private void button2_Click(object sender, EventArgs e)
            {
                IRDPSRAPIInvitation Invitation = x.Invitations.CreateInvitation("Trial", "MyGroup", "", 10);
                textBox1.Text = Invitation.ConnectionString;
            }
             
            //Share screen
    
            private void button4_Click(object sender, EventArgs e)
            {
                string Invitation = textBox1.Text;// "";// Interaction.InputBox("Insert Invitation ConnectionString", "Attention");
                axRDPViewer1.Connect(Invitation, "User1", "");
            }
    
    
            //stop sharing
            private void button5_Click(object sender, EventArgs e)
            {
                axRDPViewer1.Disconnect();
            }
        }
    }
