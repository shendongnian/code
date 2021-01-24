    public class Clientes_mdl
    {        
        public int ID_Cliente { get; set; }
        public string RazonSocial { get; set; }        
    
        [KeyAttribute]
        public Enumerador_mdl CondicionIva { get; set; }
        [KeyAttribute]
        public Nullable<Enumerador_mdl> Transporte { get; set; }
        [KeyAttribute]
        public IEnumerable<Direcciones_view> Direcciones { get; set; }
    }       
