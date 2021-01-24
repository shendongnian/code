    public class Negocio
    {
    
        public string Codigo()
        {
            var arquivo = new Arquivo();
    
            var derivadaList = new List<Geral>() {
                new derivada1(),
                new derivada2(),
                new derivada3(),
            };
    
            foreach (var derivada in derivadaList)
            {
                var result = derivada.retornaCodigo(arquivo);
                if (result == null)
                    return result;
            }
            return "";
        }
    }
