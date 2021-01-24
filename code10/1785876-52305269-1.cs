        public partial class SIMSProduct : UserControl
    {
        ITEMCount item;
        ProcessCart cart;
        public SIMSProduct()
        {
            InitializeComponent();         
        }
    
     private void btn_process_Click(object sender, EventArgs e)
        {
            cart = new ProcessCart();
            cart.Show();
            cart.lbl_price.Text = lbl_totalprice.Text; 
        }
    }
    
    public partial class ProcessCart : Form
    {     
        public ProcessCart()
        {
            InitializeComponent();
        }
     private void txt_amount_TextChanged(object sender, EventArgs e)
        {
            decimal value1;
            decimal value2;
            decimal value3;
            if (decimal.TryParse(lbl_price.Text.Trim(), out value1))
            {
                Total = Convert.ToDecimal(lbl_price.Text);            
            }
            if (decimal.TryParse(txt_amount.Text.Trim(), out value2))
            {
    
                Paid = Convert.ToDecimal(txt_amount.Text);          
            }
            if (decimal.TryParse(lbl_totalprice.Text.Trim(), out value3))
            {
                Change = Convert.ToDecimal(lbl_totalprice.Text);
            }
            Change = Paid - Total;
        }
    }
