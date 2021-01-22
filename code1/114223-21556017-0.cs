    public partial class Form1 : Form
    {
       public delegate void ProcessAnimation(bool show);
       ProcessAnimation pa;
       public Form1()
        {
            InitializeComponent();
            
            pa = this.ShowAnimation;
        }    
    private void button2_Click(object sender, EventArgs e)
        {
            
            Thread tr = new Thread(FlushToServer);
            tr.Start();
                        
        }
        private void ShowAnimation(bool show)
        {
            if (show)
            {
                loadingCircle1.Visible = true;
                loadingCircle2.Active = true;
                
            }
            else
            {
                loadingCircle1.Visible = false;
                loadingCircle1.Active = false;
                
            }
        }
        
        
        private void FlushToServer()
        {
            this.Invoke(this.pa,true);
            //your long running process
            System.Threading.Thread.Sleep(5000);
            this.Invoke(this.pa,false); 
        } 
       }
