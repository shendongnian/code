    IList<Borne> ListeBorne = new List<Borne>();
    
    NpgsqlCommand maCommandeEncaiss= new NpgsqlCommand("Select * from encaissement;", conn);    
    NpgsqlDataReader monReaderEncaiss = maCommandeEncaiss.ExecuteReader(CommandBehavior.CloseConnection);
         
    while (monReaderEncaiss.Read())
    {
        Encaissement encaiss = new Encaissement();
        encaiss.id = monReaderEncaiss.GetInt32(0);
        encaiss.mode_paiemant = monReaderEncaiss.GetString(2);
        encaiss.num_fact = monReaderEncaiss.GetString(9);
        ListEncaissement.Add(encaiss);
    }
    monReaderEncaiss.Close();
    NpgsqlCommand maCommande2 = new NpgsqlCommand("Select * from borne;", conn);
    NpgsqlDataReader monReader2 = maCommande2.ExecuteReader(CommandBehavior.CloseConnection);   
    while (monReader2.Read())
    {
        Borne b = new Borne();
        b.id = monReader2.GetInt32(0);
        b.nom = monReader2.GetString(2);
        ListeBorne.Add(b);
    }
    monReader2.Close();
    etc...
