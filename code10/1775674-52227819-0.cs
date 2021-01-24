    void btn_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        btn.BackColor = Color.Aqua;
        btn.ForeColor = Color.Red;
    
        bool found = false;
        // xy is the word that user should estimate
        for (int i = 0; i < xy.Length; i++)
        {
            if (this.Controls.Find("txt" + i, true)[0].Text == btn.Text)
            {
                this.Controls.Find("txt" + i, true)[0].Text = btn.Text;
                this.Controls.Find("txt" + i, true)[0].BackColor = Color.White;
				found = true;
            }
        }
		if (!found)
        {
            a++;
            switch(a)
            {
                case 1:
                    pictbx.Image = Image.FromFile("D:/Csharp_Pro/Games/Mine/hangman/hangman/skeleton1.png");
                    break;
                case 2:
                    pictbx.Image = Image.FromFile("D:/Csharp_Pro/Games/Mine/hangman/hangman/skeleton2.png");
                    break;
                case 3:
                    pictbx.Image = Image.FromFile("D:/Csharp_Pro/Games/Mine/hangman/hangman/skeleton3.png");
                    break;
                case 4:
                    pictbx.Image = Image.FromFile("D:/Csharp_Pro/Games/Mine/hangman/hangman/skeleton4.png");
                    break;
                case 5:
                    pictbx.Image = Image.FromFile("D:/Csharp_Pro/Games/Mine/hangman/hangman/skeleton5.png");
                    break;
                default:
                    break;
    
            }
        }
    }
