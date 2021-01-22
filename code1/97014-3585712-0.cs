        private void AdicionarControlesDinamicamente(int idPergunta)
    {
        if (idPergunta > 0)
        {
            this.IdPerguntaAtual = idPergunta;
            PerguntaAtual = new Pergunta(this.IdPerguntaAtual);
            UserControl uc = LoadControl(PerguntaAtual.TipoResposta.CaminhoUserControl, PerguntaAtual.IdPergunta);
            phResposta.Controls.Add(uc);
            ViewState["ControlesDinamicosPerguntaCarregados"] = true;
        }
    }
