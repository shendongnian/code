    class MyForm
    {
        private Dictionary<String, Image> images = new Dictionary<String, Image>();
        public void Init()
        {
             images["apple"] = Properties.Resources.apple;       
        }
        public void Dispose()
        {
            foreach(var item in myDictionary.Values)
            {
               item.Dispose();
            }  
        }
        private void apple1_Click(object sender, EventArgs e)
        {
            apple1.Image = images["apple"];
            bool condition = true;
            if (apple1.Image==apple2.Image)
            {
                apple1.Visible = false;
                apple2.Visible = false;
            }
        }
        private void apple2_Click(object sender, EventArgs e)
        {
            apple2.Image = images["apple"];
        }
    }
