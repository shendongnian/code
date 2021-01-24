    public string Codigo()
    {
        var arquivo = new Arquivo();
        List<Geral> gerals=new List<Geral>();
        gerals.Add(new derivada1());
        gerals.Add(new  derivada2());
         ........
         ...........
       foreach(Geral g in gerals)
       {
         var val=g.retornaCodigo(arquivo);
         if(val!=null)
            return val;
        }
        return "";
    }
