        [XmlRoot(ElementName = "CLIENTE")]
        public class Client
        {
            [XmlElement(ElementName = "ROW")]
            public List<ClientInfo> Row { get; set; }
        }
        [Serializable]
        [XmlRoot(ElementName = "ROW")]
        public class ClientInfo
        {
            [XmlElement(ElementName = "TABELA")]
            public string NomeTabela { get; set; }
            [XmlElement(ElementName = "ID_CLIENTE", Type = typeof(int))]
            public int ClienteID { get; set; }
            [XmlElement(ElementName = "ID_CLIENTE_RECADASTRO")]
            public string ClientIDRecadastro { get; set; }
            [XmlElement(ElementName = "NOME_CLIENTE")]
            public string NomeCliente { get; set; }
            [XmlElement(ElementName = "TIPO_CLIENTE")]
            public string TipoCliente { get; set; }
            [XmlIgnore]
            public DateTime DataRecadastro { get; set; }
