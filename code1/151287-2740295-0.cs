    using (FileStream apt_file = new FileStream(textBox1.Text, FileMode.Open, FileAccess.Read))
    {
        textBox1.Text = textBox1.Text.Replace(".txt", "_mod.txt");
        using (FileStream mdi_file = new FileStream(textBox1.Text, FileMode.OpenOrCreate, FileAccess.ReadWrite))
        {
            //lecture/ecriture des fichiers en question 
            using (StreamReader apt = new StreamReader(apt_file))
            using (StreamWriter mdi_line = new StreamWriter(mdi_file, System.Text.Encoding.UTF8, 16))
            {
                while (apt.Peek() >= 0)
                {
                    ma_ligne = apt.ReadLine();
                    //if (ma_ligne.StartsWith("GOTO")) 
                    //{ 
                    //   ma_ligne = ma_ligne.Remove(0, RMV_CARCT); 
                    //   ma_ligne = ma_ligne.Replace(" ",""); 
                    //   ma_ligne = ma_ligne.Replace(",", " "); 
                    mdi_line.WriteLine(ma_ligne);
                    //} 
                }
            }
        }
    }
