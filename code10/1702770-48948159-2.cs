    using(var db = new EntityContext())
    {
        var cubos = db.CubosTrabalhados;
        string[] lines = File.ReadAllLines(Files.cuboHistorico, Encoding.Default);
        bool header = true;
        int i = 2;
        
        foreach (string line in lines)
        {
            if (header) header = false;
            else
            {
                var reg = line.Split(';');
                var cubo = new CuboTrabalhado();
                cubo.Pedido = reg[0];
                
                ...
    
                cubos.Add(cubo);
            }
        }
        db.SaveChanges(); 
    }
    
