      private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string endword = "";          
            int chrnumber = int.Parse(this.comboBox1.GetItemText(this.comboBox1.SelectedItem).ToString());// change line
            string[] Nochars = { "q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "[", "]", "a", "s", "d", "f", "g", "h", "j", "k", "l", ";", "'", "#", "z", "x", "c", "v", "b", "n", "m", "/", "Q", "W", "E", "R", "T", "Y", "U", "I", "O", "P", "{", "}", "A", "S", "D", "F", "G", "H", "J", "K", "L", ":", "@", "~", "Z", "X", "C", "V", "B", "N", "M", "<", ">", "?", "!", "£", "$", "%", "^", "&", ".*", "(", ")", "_", "+", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "-", "=" };
            Random rndchar = new Random();
            for (int i = 0; i < chrnumber; i++)
            {
               
                int iSelect = rndchar.Next(0, Nochars.Length);
                string word1 = Nochars[iSelect];
                string word2 = word1;
                if (i == 0) {
                    endword = word1;
                }
                else {
                    endword += "." + word2;
                }
            }
            pwd.Text = endword;
        }
