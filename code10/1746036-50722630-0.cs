        using (var ctx = new BazyDanychContext())
        {
            Osoba tmpTask = new Osoba { ID = IDLbl.Text, Imie = ImieLbl.Text, Nazwisko = NazwiskoLbl.Text, Telefon = TelefonLbl.Text, Adres = AdresLbl.Text, Mail = MailLbl.Text, IloscTransakcji = Int32.Parse(IloscLbl.Text), Typ = TypList.Text };
            ctx.Osoba.Add(tmpTask);
            ctx.SaveChanges();
        }
