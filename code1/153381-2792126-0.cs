    protected void Button1_Click(object sender, EventArgs e) { double sayi1, sayi2, sayi3, hesap, sonuc;
    
        sayi1 = Convert.ToDouble(Tb1.Text);
        sayi2 = Convert.ToDouble(Tb2.Text);
        sayi3 = Convert.ToDouble(Tb3.Text);
    
        if (Tb1.Text.Length > 6 || Tb2.Text.Length > 6)
        {
            lbl1.Text = "ERROR.";
            if (session["currentTb1"] != null && session["currentTb2"] != null){
                 Tb1.Text = session["currentTb1"].toString();
                 Tb2.Text = session["currentTb2"].toString();
            }
        }
        else
        {
            hesap = (((sayi1 - ((sayi1 - sayi2) / 2)) * ((sayi1 - sayi2) / 2)) / 40);
            sonuc = (hesap * sayi3) / 100;
            lbl1.Text = sonuc.ToString() + "kg";
            session["currentTb1"] = Tb1.Text;
            session["currentTb2"] = Tb2.Text;
        }
    
    
    }
