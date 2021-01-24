    bool AbrirDataAtual(IWebDriver driver, string data)
    {
        try
        {
            //Do all the neccessary stuff
            ...
            //Indicate that AbrirDataAtual succeeded
            return true;
        }
        catch(Exception)
        {
            //Handle exception properly
            ...
            //Indicate that AbrirDataAtual failed
            return false;
        }
    }
    private async Task<List<IWebElement>> Acessar(IWebDriver driver, string data, CancellationToken ct)
    {
        return await Task.Run(() =>
        {
            ct.ThrowIfCancellationRequested();
            LoginNgin.Login(config.User, config.Password, driver);
            RelatoriosEstaticos.AbrirRelatoriosEstaticos(driver);
            if (RelatoriosEstaticos.AbrirDataAtual(driver, data))
            {
                //Continue execution
                var links = ListArquivos.ListaLinksDownlaod(driver);
                MethodInvoker action = delegate { pgbStatus.Maximum = links.Count(); };
                pgbStatus.BeginInvoke(action);
                return links;
            }
            else
            {
                //AbrirDataAtual failed
                return null;
                //or throw exception if appropriate
                throw new Exception();
            }
        });
    }
