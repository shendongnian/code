    public partial class FrmPrincipal : Form
    {
        private string token;
    
        public FrmPrincipal()
        {
            InitializeComponent();
            ...
        }
    
        private void menuItem1_Click(object sender, EventArgs e)
        {
            int width = Width;
            int height = Height;
            Thread t = new Thread(() => RequestImage(width, height));
            t.Start();
        }
    
        private void RequestImage(int width, int height)
        {
            try
            {
                ...
    
                int alto = height;
                int ancho = width;
                this.token = "...";
    
                ...
            }
            catch (Exception ex)
            {
                ...
            }
        }
    }
