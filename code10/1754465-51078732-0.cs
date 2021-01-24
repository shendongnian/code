    //My list
    List<UA> listagem = new List<UA>();
    //My class
    public class UA
        {
            public string DistritoCod { get; set; }
            public string Distrito { get; set; }
            public UA() { }
        }
    
    //Then this to tell where I wanted the values to go
       UA ua = new UA { };
                ua.DistritoCod = row.Cell(1).GetString();
                ua.Distrito = row.Cell(2).GetString();
    
    listagem.Add(ua);
    datagridview1.datasource = listagem;
