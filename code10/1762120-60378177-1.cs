        try
        {
            IApiHgFinance ApiHgFinance = Refit.RestService.For<IApiHgFinance>("https://api.hgbrasil.com/finance");
            var result = await ApiHgFinance.GetTaxes();
            var jo = Newtonsoft.Json.Linq.JObject.Parse(result);
            var taxes = jo["results"].ToObject<itemTaxes[]>();
            foreach (var item in taxes)
            {
                MessageBox.Show($"Taxa CDI   : {item.Cdi} \nTaxa Selic : {item.Selic} \nData Atualização: {item.Date}",
                    "Atualização de informações", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro: {ex.Message}", "Erro ao tentar recuperar as taxas do dia.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
