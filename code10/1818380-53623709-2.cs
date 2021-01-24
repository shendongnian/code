        private void button2_Click(object sender, EventArgs e)
        {
            // Assuming you clicked button 1 first, 
            // this will not cause a new instance but use the existing one
            var singleton = Singleton.Instance;
            var f = singleton.AdminForm;
            f.LabelText = "Hello world!";
        }
