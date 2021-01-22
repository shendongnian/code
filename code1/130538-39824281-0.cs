           //below code is to find the count of a specific node in the XML Document
     private void browse_Click(object sender, EventArgs e)//file browse button
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                String file = openFileDialog1.FileName;
                if (Path.GetExtension(file) != ".xml")
                {
                    MessageBox.Show("Please upload an vaild xml file");
                    textBox1.Clear();
                }
                else
                {
                    textBox1.Text = file;
                }
            }
        }  
     private void CountButton_Click(object sender, EventArgs e)//count button
        {
            int count = 0;
            string element = textBox2.Text;//Enter the node in the textbox
            XmlDocument readdoc = new XmlDocument();
                readdoc.Load(textBox1.Text);
                XmlElement root = readdoc.DocumentElement;
                XmlNodeList node = root.GetElementsByTagName(element);
                count = node.Count;
                MessageBox.Show(string.Format("Count of {0} node in the uploaded xml file is {1}", element, count.ToString()));
        }
