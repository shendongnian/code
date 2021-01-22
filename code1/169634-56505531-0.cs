    namespace A8
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            class Proizvod {
                public string ceo_red, ime, proizvodjac, ram, tip, kamera,slika, ekran,sifra, cena;
                
                public Proizvod(string x) {
                    ceo_red = x;
                    slika = x.Split(',')[0];
                    sifra = x.Split(',')[1];
                    ime = x.Split(',')[2];
                    proizvodjac = x.Split(',')[3];
                    ram = x.Split(',')[4];
                    tip = x.Split(',')[5];
                    kamera = x.Split(',')[6];
                    ekran = x.Split(',')[7];
                    cena = x.Split(',')[8];
                }
            
            }
            List<Proizvod> proizvodi = new List<Proizvod>();
            protected void Page_Load(object sender, EventArgs e)
            {
                    
                StreamReader sr = new StreamReader(@"F:\dji\A8\A8\TextFile1.txt");
                for (int i = 0; i < 5; i++)
                {
                    proizvodi.Add(new Proizvod(sr.ReadLine()));
                }
                for (int i = 0; i < proizvodi.Count; i++)
                {
                    bool isti = false;
                    for (int j = 0; j < DropDownList1.Items.Count; j++)
                    {
                        if (proizvodi[i].proizvodjac == DropDownList1.Items[j].Text) isti = true;
                    }
                    if (!isti) DropDownList1.Items.Add(proizvodi[i].proizvodjac);
                    isti = false;
                    for (int j = 0; j < DropDownList2.Items.Count; j++)
                    {
                        if (proizvodi[i].ram == DropDownList2.Items[j].Text) isti = true;
                    }
                    if (!isti) DropDownList2.Items.Add(proizvodi[i].ram);
                    isti = false;
                    for (int j = 0; j < DropDownList3.Items.Count; j++)
                    {
                        if (proizvodi[i].tip == DropDownList3.Items[j].Text) isti = true;
                    }
                    if (!isti) DropDownList3.Items.Add(proizvodi[i].tip);
                    isti = false;
                    for (int j = 0; j < DropDownList4.Items.Count; j++)
                    {
                        if (proizvodi[i].kamera == DropDownList4.Items[j].Text) isti = true;
                    }
                    if (!isti) DropDownList4.Items.Add(proizvodi[i].kamera);
                    isti = false;
                    for (int j = 0; j < DropDownList5.Items.Count; j++)
                    {
                        if (proizvodi[i].ekran == DropDownList5.Items[j].Text) isti = true;
                    }
                    if (!isti) DropDownList5.Items.Add(proizvodi[i].ekran);
                }
                Table1.Visible = false;
            }
            protected void Button1_Click(object sender, EventArgs e)
            {
                List<Proizvod> trazeni = new List<Proizvod>();
                for (int i = 0; i < proizvodi.Count; i++)
                {
                    if (proizvodi[i].proizvodjac == DropDownList1.Text && proizvodi[i].ram == DropDownList2.Text && proizvodi[i].tip == DropDownList3.Text && proizvodi[i].kamera == DropDownList4.Text && proizvodi[i].ekran == DropDownList5.Text)
                    {
                        
                        trazeni.Add(proizvodi[i]);
                    }
                }
                for (int i = 0; i < trazeni.Count; i++)
                {
                    TableRow tr = new TableRow();
                    for (int j = 0; j < 9; j++)
                    {
                        TableCell tc = new TableCell();
                        
                        tc.Text = trazeni[i].ceo_red.Split(',')[j];
                        tr.Cells.Add(tc);
                    }
                    Table1.Rows.Add(tr);
                }
                Table1.Visible = true;
            }
        }
    }
