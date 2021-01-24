    private void btnApply_Click(object sender, EventArgs e)
        {
            using (StreamWriter stream = new StreamWriter(richTbWrite.Text, true))
            {
                stream.WriteLine("some text here");
            }
        }
