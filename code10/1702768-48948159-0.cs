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
                cubo.DataPedido = Select.ParseDate(reg[3]);
                cubo.Cliente = reg[4];
                cubo.UF = Select.Uf(reg[5]);
                cubo.Cidade = reg[6];
                cubo.Regiao = reg[7];
                cubo.Codigo = reg[8];
                cubo.Produto = reg[9];
                ...
                cubo.VlCom = Select.ParseFloat(reg[63]);
                cubo.Cnpj = reg[64];
                cubo.CodProdOriginal = reg[65];
    
                cubos.Add(cubo);
                db.SaveChanges(); 
            }
        }
    }
    
