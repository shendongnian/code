    public partial class Form2 : Form
    {   
        public event EventHandler DataSourceUpdated;
           ...   
        private void button2_Click(object sender, EventArgs e)  //Done button   
        {
           if (this.DataSourceUpdated != null) //raise the event       
            {           
                this.DatasourceUpdated(this, EventArgs.Empty);       
            }       
            this.Close();   
        }
