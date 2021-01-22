    public string Sifre_Uret(int boy, int noalfa)
    {
        //  01.03.2016   
        // Genel amaçlı şifre üretme fonksiyonu
        //Fonskiyon 128 den büyük olmasına izin vermiyor.
        if (boy > 128 ) { boy = 128; }
        if (noalfa > 128) { noalfa = 128; }
        if (noalfa > boy) { noalfa = boy; }
        
        string passch = System.Web.Security.Membership.GeneratePassword(boy, noalfa);
        //URL encoding ve Url Pass + json sorunu yaratabilecekler pass ediliyor.
        //Microsoft Garanti etmiyor. Alfa Sayısallar Olabiliyorimiş . !@#$%^&*()_-+=[{]};:<>|./?.
        //https://msdn.microsoft.com/tr-tr/library/system.web.security.membership.generatepassword(v=vs.110).aspx
        //URL ve Json ajax lar için filtreleme
        passch = passch.Replace(":", "z");
        passch = passch.Replace(";", "W");
        passch = passch.Replace("'", "t");
        passch = passch.Replace("\"", "r");
        passch = passch.Replace("/", "+");
        passch = passch.Replace("\\", "e");
        passch = passch.Replace("?", "9");
        passch = passch.Replace("&", "8");
        passch = passch.Replace("#", "D");
        passch = passch.Replace("%", "u");
        passch = passch.Replace("=", "4");
        passch = passch.Replace("~", "1");
        passch = passch.Replace("[", "2");
        passch = passch.Replace("]", "3");
        passch = passch.Replace("{", "g");
        passch = passch.Replace("}", "J");
        //passch = passch.Replace("(", "6");
        //passch = passch.Replace(")", "0");
        //passch = passch.Replace("|", "p");
        //passch = passch.Replace("@", "4");
        //passch = passch.Replace("!", "u");
        //passch = passch.Replace("$", "Z");
        //passch = passch.Replace("*", "5");
        //passch = passch.Replace("_", "a");
        passch = passch.Replace(",", "V");
        passch = passch.Replace(".", "N");
        passch = passch.Replace("+", "w");
        passch = passch.Replace("-", "7");
        
        
        
        return passch;
    }
