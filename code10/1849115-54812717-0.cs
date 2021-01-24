    Detalhes = new List<DetalhesExcel>() {
        new DetalhesExcel()
        {
            NumColunaInicial = 23,
            Coluna1 = "Representante",
            Coluna2 = "ValorRepasse",
            Coluna3 = "KmRepasse"
        }
    };
    
    Detalhes.AddRange(ocorrencias.Where(x => x.Conclusao != "PRÓPRIO")
        .GroupBy(x => x.Representante)
        .Select(x => new DetalhesExcel
        {
            NumColunaInicial = 23,
            Coluna1 = x.First().Representante,
            Coluna2 = x.Sum(y => y.ValorRepasse).ToString(),
            Coluna3 = x.Sum(y => y.KmRepasse).ToString()
        }).ToList())
