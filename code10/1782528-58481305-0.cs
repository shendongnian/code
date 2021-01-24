        public static void QuickReplace(RichTextBox rtb, String word, String word2)
        {
            rtb.Text = rtb.Text.Replace(word, word2);
        }
        private void button1_Click(object sender, EventArgs e)
        {
                QuickReplace(richTextBox1, textBox1.Text, textBox2.Text);
        }
