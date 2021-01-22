    database = new OleDbConnection(connectionString);
                    database.Open();
                    date = DateTime.Now.ToShortDateString();
                    string queryString = "SELECT SUM(skupaj_kalorij)as Skupaj_Kalorij  "
                        + "FROM (obroki_save LEFT JOIN users ON obroki_save.ID_uporabnika=users.ID)" 
                        + "WHERE users.ID= " + a.ToString()+" AND obroki_save.datum= '" +DateTime.Today.ToShortDateString() + "'";
                    loadDataGrid2(queryString);
