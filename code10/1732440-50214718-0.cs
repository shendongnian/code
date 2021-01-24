    public static void SetCookie(this HttpResponse response, string chave, string valor, int? dataExpiracao) {
        CookieOptions option = new CookieOptions();
        if (dataExpiracao.HasValue)
            option.Expires = DateTime.Now.AddMinutes(dataExpiracao.Value);
        else
            option.Expires = DateTime.Now.AddMilliseconds(10);
        response.Cookies.Append(chave, valor, option);
    }
