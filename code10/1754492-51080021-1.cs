        List<UA> listagem = new List<UA>();
        public string currentmap = "http://maps.google.com/maps?=";
        public string lat;
        public string lon;
        public string resulttestt;
        public class UA
        {
            public string DistritoCod { get; set; }
            public string Distrito { get; set; }
            public string ConcelhoCod { get; set; }
            public string Concelho { get; set; }
            public string IDEndereço { get; set; }
            public string TipoDeRua { get; set; }
            public string Endereço { get; set; }
            public string IDLocalidade { get; set; }
            public string Localidade { get; set; }
            public string CP4 { get; set; }
            public string CP3 { get; set; }
            public string NumPolicia { get; set; }
            public string Andar { get; set; }
            public string Fracçao { get; set; }
            public string Edificio_cad { get; set; }
            public string Celula { get; set; }
            public string Latitude { get; set; }
            public string Longitude { get; set; }
            public string Tpo_HP { get; set; }
            public string NomeEmpresa { get; set; }
            public string ValidaçaoMoradas { get; set; }
            public string Comentario { get; set; }
            public UA() { }
        }
