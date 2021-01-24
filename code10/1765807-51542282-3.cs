        [JsonProperty("Viagem.Id")]
        public int Id { get; set; }
        [JsonProperty("Viagem.Status")]
        public string Status { get; set; }
        [JsonProperty("Viagem.Navio.Nome")]
        public string Navio_Nome { get; set; }
        [JsonProperty("Viagem.Navio.ImagemNavio")]
        public string ImagemNavio { get; set; }
        [JsonProperty("Viagem.Navio.Armador.Id")]
        public int? Armador_Id { get; set; }
        [JsonProperty("Viagem.Navio.Armador.Nome")]
        public string Armador_Nome { get; set; }
