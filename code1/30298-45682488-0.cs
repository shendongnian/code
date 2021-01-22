    this.MouseWheel += pictureBox1_MouseWheel; //tanımlama
    void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
                {
                    if (Convert.ToString(e.Delta) == "120")
                    {
                        //yukarı
                    }
                    else if (Convert.ToString(e.Delta) == "-120")
                    {
                        //aşağı
                    }
                }
