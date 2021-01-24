        public class Form2: Form 
        {
            //{...}
            public string SelectedPath { get; set;}
            //{...}
            private void Form2_Load(object sender, EventArgs e)
            {       
                 webBrowser1.Url = new Uri(this.SelectedPath);
             }
        }
    
        private void Showfrm2Btn_Click(object sender, EventArgs e)
        {
           Form2 Frm2 = new Form2();
           Frm2.SelectedPath = txtpath.Text;
           Frm2.ShowDialog();
        }
