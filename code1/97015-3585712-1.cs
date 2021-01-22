        protected override void CreateChildControls()
    {
        base.CreateChildControls();
        // CHeck if the controls have been added to page, case true, i call IncluirControlesDinamicamente() again
        // The Asp.Net will look into viewstate and wil find my controls there, so "he" will recreate their for me
        if (ViewState["ControlesDinamicosPerguntaCarregados"] != null)
            if (Page.IsPostBack)
                AdicionarControlesDinamicamente(this.IdPerguntaAtual);
    }
