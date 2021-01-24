       private string _nome ;
       public string Nome
        {
            get => _nome ?? "Nome não informado.";
            private set => _nome = value ?? "Nome não informado.";
        }
        private string _email; 
        public string Email
        {
            get => _email?? "Email não informado.";
            private set => _email= value ?? "Email não informado.";
        }
        private string _denucia;
        [Required(ErrorMessage = "A denuncia não possui o texto obrigatório do seu conteúdo. (Corpo da Mensagem)")]
        public string Denuncia
        {
            get => _denucia?? "O texto da denuncia não foi encontrado.";
            private set => _denucia= value ?? throw new ArgumentNullException("O campo denúncia é obrigatório.");
        }
