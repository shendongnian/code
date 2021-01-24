    [HttpGet]
    [Route("SelecionarIdioma")]
    public IActionResult SelecionarIdioma(string cultura) {
        Response.SetCookie("idioma", cultura, 60); //<-- extension method.    
        return RedirectToAction("Index", "Grupo");
    }
