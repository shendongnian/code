      public delegate void ShowForm(object sender, MessageEventArgs e);
      public partial class Form1 : Form
      {
         public Form1()
         {
            InitializeComponent();
            ConnectionManagerThread.getResponseListener().MessageReceived += Form1_OnMessageReceived;
         }
    
         private void Form1_OnMessageReceived(object sender, MessageEventArgs e)
         {
             if (this.InvokeRequired)
             {
                this.BeginInvoke(new ShowForm(new object[] { sender, e }));
             }
             else
             {
                Form2 f2 = new Form2();
                f2.Show();
             }
          }
      }
