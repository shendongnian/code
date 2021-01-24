    int sonuc = 0;
    int sayi1;
    int sayi2;
    
    if (!int.TryParse(ilkSayi.Text, out sayi1))
    {
        hata_labeli.ForeColor = System.Drawing.Color.Maroon;
        hata_labeli.Text = "Tam sayı yerina başka bir değer girilmiş!"; // ilkSayi message
    }    
    else if (!int.TryParse(ikinciSayi.Text, out sayi2))
    {
        hata_labeli.ForeColor = System.Drawing.Color.Maroon;
        hata_labeli.Text = "Tam sayı yerina başka bir değer girilmiş!"; // ikinciSayi message
    }
    
    // use the values..
