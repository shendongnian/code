    var model = new IndexVM
    {
      items = Empresas
        .Select(emp => new MyClass { Name = emp.Nome, Estagios = Estagios })
        .Where(x => x.Empresa.EmpresaID == emp.EmpresaID && x.AnoLetivo == AnoLetivo).Count() })
        .OrderBy(y => y.Numero_Estagios)
        .Take(5)
        .ToList()
    }
    return View(model);
