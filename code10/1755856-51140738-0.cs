    [HttpPost]
    public ActionResult BuscarExpediente(Entrega02Programacion03.Models.Expediente model)
    {
    	int? Codigo = model.Codigo;
    	int? Cedula = model.Solicitante?.Cedula;
    	string Email = model.Funcionario?.Email;
    
        //Expediente expediente = db.Expediente.Find(id);
        //var expediente = db.Expediente.SingleOrDefault(e => e.Codigo == id);
        //si me dan el id de expediente lo busco de esta forma
        if ((Codigo != null) &&(Cedula == null) &&(Email == null))
        {
    
            //var expediente = db.Expediente.Where(E => E.Codigo == Codigo).SingleOrDefault();
            //return View(expediente);
            TempData["idExpedienteBuscar"] = Codigo;
            return RedirectToAction("ExpedientesPorId");
    
        }
        //si me dal la cedula de un solicitante busco de esta forma
        if((Cedula != null)&& (Email == null)&& (Codigo == null))
        {
            TempData["ExpedientesCedulaSolicitante"] = Cedula;
            return RedirectToAction("ExpedientesPorCedulaSolicitante");
    
        }
        //si me dan un funcionario busco de esta forma
        if((Email != null)&& (Codigo == null) && (Cedula == null))
        {
            TempData["ExpedienteBuscarFuncionarioID"] = Email;
            return RedirectToAction("ExpedientesPorFuncionario");
        }
        //si no me dan nada busco de estra otra
         else
        {
            //que de el mensaje de que solo se puede insertar un campo de busqueda
            //hay que poner en el view un label o algo para tirar el msj
        }
    
        //ViewBag.FechInicio = expediente.FechaCreacion;
        //ViewBag.Tramite = expediente.Tramite.Titulo;
        //ViewBag.Funcionario = expediente.Funcionario.Nombre;
        return View();
    }
