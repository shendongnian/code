    public class Viagem 
    {
        public int Id {get; set;}
        public string NumeroAtracacao {get; set;}
        public string Status {get; set;}
        public string Joint {get; set;}
        public string Servico {get; set;}
        public string MotivoEspera {get; set;}
        public Navio Navio {get; set;}
        public DateTime ChegadaPrevista {get; set;}
        public DateTime AtracacaoPrevista {get; set;}
        public DateTime SaidaPrevista {get; set;}
        public DateTime DeadLine {get; set;}
    }
    
    public class Navio 
    {
        public string Nome {get; set;}
        public Armador Armador {get; set;}
        public string ImagemNavio {get; set;}
        public int Comprimento {get; set;}
        public int Lloyd {get; set;}
        public string CallSign {get; set;}
        public string CapacidadeTeus {get; set}
        public string Shortname {get; set;}
    }
    
    public class Armador 
    {
        public int Id {get; set;}
        public object CodigoGeParcei {get; set;}
        public string Nome {get; set;}
        public string Sigla {get; set;}
        public object CnpjCpf {get; set;}
        public object Endereco {get; set;}
        public object Cep {get; set;}
        public object Site {get; set;}
    }
