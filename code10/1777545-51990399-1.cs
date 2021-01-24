        private void button1_Click(object sender, EventArgs e)
        {
    
            StreamReader reader = File.OpenText("cru-ts-2-10.1991-2000-cutdown.pre");
    
            string line;
    
            var regex = new Regex(@"(Grid)");
    
            List<String> HeaderParse = new List<string>();
    
            while ((line = reader.ReadLine()) != null && !regex.IsMatch(line))
            {
                 HeaderParse.Add(line);
                
            }
            MessageBox.Show("This button has been clicked");
        }
