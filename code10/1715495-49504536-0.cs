    using System.Xml.Linq;
    public ActionResult Foo()
    {
        var xml = XDocument.Load("http://servicos.cptec.inpe.br/XML/listaCidades");
        var nodes = xml.Descendants("nome");
        var xElements = nodes as XElement[] ?? nodes.ToArray();
        var foo = new List<string>();
        xElements.ForEach(element => foo.Add(element.Value));
        ViewData["Nomes"] = new SelectList(foo);
        return View();
    }
