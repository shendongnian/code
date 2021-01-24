    private async Task<List<IWebElement>> Acessar(IWebDriver driver, string data, CancellationToken ct)
    {
        return await Task.Run(() =>
        {
            ct.ThrowIfCancellationRequested();
            LoginNgin.Login(config.User, config.Password, driver);
            RelatoriosEstaticos.AbrirRelatoriosEstaticos(driver);
            try
            {
                RelatoriosEstaticos.AbrirDataAtual(driver, data);
                var links = ListArquivos.ListaLinksDownlaod(driver);
                MethodInvoker action = delegate { pgbStatus.Maximum = links.Count(); };
                pgbStatus.BeginInvoke(action);
                return links;
            }
            catch (Exception)//Use more specific exception type if possible
            {
                //Do all neccesary to properly handle the exception
            }
        });
    }
