    OleDbConnection con = new OleDbConnection(Utility.GetConnection());
            con.Open();
            OleDbCommand cmd2 = new OleDbCommand("INSERT INTO Temsilci(isin_adi,isin_tanimi,verildigi_tarih,teslim_tarihi,sorumlu_marka,sorumlu_ajans,revize,Temsilci_isverenid) values (@isinadi,@isintanimi,@vertarih,@testarih,@smarka,@sajans,@revize,@temsid)", con);
            cmd2.Parameters.Add("isinadi", txtisAdi.Text);
            cmd2.Parameters.Add("isintanimi", txtMarkaAdi.Text); 
            cmd2.Parameters.Add("vertarih", txtverilisTarihi.Text);
            cmd2.Parameters.Add("testarih", txtTeslimTarihi.Text);       
            cmd2.Parameters.Add("smarka", txtMarkaTemsilcisi.Text);
            cmd2.Parameters.Add("sajans", txtAjansTemsilcisi.Text);
            cmd2.Parameters.Add("revize", txtSorumluKisiler.Text);        
            cmd2.Parameters.Add("temsid", Session["UserID"]);
            cmd2.ExecuteNonQuery();
            con.Close(); 
   
