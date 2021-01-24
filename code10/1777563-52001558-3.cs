    public partial class FormResultadosFotos : Form
    {
    	// This is the constructor that we have added to the FormResultadosFotos so it can receive the DataTable that was created on the previous form
    	Public FormResultadosFotos(DataTable table)
    	{
    		InitializeComponent();
    		dataGridView1.DataSource = table;
            dataGridView1.Columns[1].Visible = true;
    		// What can be done here to not block the UI thread if is being blocked while populating the dataGridView1, is to create another BackgroundWorker here and populate the dataGridView1 there
    	}
    	
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            var myForm = new FormPictureBox();
            string imageName = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            var img = Image.FromFile(imageName);
    
            myForm.pictureBox1.Image = img;
            myForm.ShowDialog();
        }
    }
