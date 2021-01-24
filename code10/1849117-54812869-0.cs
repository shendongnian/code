        class Program
    {
        static void Main(string[] args)
        {
            List<Ocorrencia> ocorrencias = new List<Ocorrencia>() {
                new Ocorrencia() {
                    Conclusao = "teste",
                    KmRepasse = 1,
                    Representante = "um",
                    ValorRepasse = 2
                }
            };
            var Detalhes = new List<DetalhesExcel>() {
                    new DetalhesExcel()
                    {
                        NumColunaInicial = 23,
                        Coluna1 = "Representante",
                        Coluna2 = "ValorRepasse",
                        Coluna3 = "KmRepasse"
                    }
                }.Concat(ocorrencias.Where(x => x.Conclusao != "PRÓPRIO")
                                .GroupBy(x => x.Representante)
                                .Select(x => new DetalhesExcel
                                {
                                    NumColunaInicial = 23,
                                    Coluna1 = x.First().Representante,
                                    Coluna2 = x.Sum(y => y.ValorRepasse).ToString(),
                                    Coluna3 = x.Sum(y => y.KmRepasse).ToString()
                                }).ToList());
        }
    }
    public class Ocorrencia
    {
        public string Conclusao { get; set; }
        public string Representante { get; set; }
        public int KmRepasse { get; set; }
        public int ValorRepasse { get; set; }
    }
    public class DetalhesExcel
    {
        public int NumColunaInicial { get; set; }
        public string Coluna1 { get; set; }
        public string Coluna2 { get; set; }
        public string Coluna3 { get; set; }
        public string Coluna4 { get; set; }
        public string Coluna5 { get; set; }
    }
