    var model = new IndexVM
    {
      items = Empresas
        .Select(emp => new MyClass { 
            Nome = emp.Nome, 
            Numero_Estagios = Estagios.Where(x => x.Empresa.EmpresaID == emp.EmpresaID && x.AnoLetivo == AnoLetivo).Count() 
        })
        .OrderBy(y => y.Numero_Estagios)
        .Take(5)
        .ToList()
    }
    return View(model);
