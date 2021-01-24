    public ActionResult ReservasHoy()
        {
            DateTime today = DateTime.Today;
            var result = (from p in db.Reservas
                         where DbFunctions.TruncateTime(p.fecha) == today
                         select p)
                         .ToList()
                         .Select(x=>new Project.Models.Reserva 
                         { 
                          Reservas_Tipo=x.Reservas_Tipo, 
                          Cliente=x.Cliente, 
                          fecha=x.fecha 
                         }).ToList();
    
            var r = result.ToList();
            return View(r);
        }
