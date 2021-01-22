    protected void btDodaj_Click(object sender, EventArgs e)
    {
        using(DataClassesDataContext db = new DataClassesDataContext())
        {
          Dziecko dz = new Dziecko();
          dz.imie = this.tbImieDz.Text;
          dz.nazwisko = this.tbNazwiskoDz.Text;
          dz.nrGrupy = Convert.ToInt32(this.dropGrupa.SelectedValue);
        
          Opiekun op = new Opiekun();
          dz.Opiekun.Add(op);   //Linq to Sql will handle it
          op.imie = this.tbImieRodz.Text;
          op.nazwisko = this.tbNazwiskoRodz.Text;
          op.telefon = Convert.ToInt32(this.tbTel.Text);
          db.Dzieckos.InsertOnSubmit(dz);
          db.SubmitChanges();
          Label2.Text = "Dodano " + this.tbImieDz.Text.ToString() + " " + this.tbNazwiskoDz.Text.ToString(); 
        } 
    }
