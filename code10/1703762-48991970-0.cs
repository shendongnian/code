    int sonuc = 0;
    
    if (!int.TryParse(ilkSayi.Text, out int sayi1))
    {
        hata_labeli.ForeColor = System.Drawing.Color.Maroon;
        hata_labeli.Text = "Tam sayı yerina başka bir değer girilmiş!"; // ilkSayi message
    }
    
    if (!int.TryParse(ikinciSayi.Text, out int sayi2))
    {
        hata_labeli.ForeColor = System.Drawing.Color.Maroon;
        hata_labeli.Text = "Tam sayı yerina başka bir değer girilmiş!"; // ikinciSayi message
    }
    // use the values..
