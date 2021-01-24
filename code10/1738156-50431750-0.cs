    public List<string> Articole { get; set; } = new List<string>();
    public Facturi Factura { get; set; }
    public Comenzi(int nrcomanda, DateTime datacomanda, DateTime datalivrare, Facturi _factura, List<string> _articole)
    {
        NrComanda = nrcomanda;
        DataComanda = datacomanda;
        DataLivrare = datalivrare;
        Factura = _factura;
        Articole.AddRange(_articole.ToArray());
    }
