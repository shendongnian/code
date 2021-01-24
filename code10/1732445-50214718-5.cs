    [HttpGet]
    [Route("SelecionarIdioma")]
    public IActionResult SelecionarIdioma(string cultura) {
        Response.AddCookie("idioma", cultura, 60); //<-- extension method.    
        return RedirectToAction("Index", "Grupo");
    }
