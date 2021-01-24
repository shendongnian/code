    public ActionResult ReservasHoy()
        {
            DateTime today = DateTime.Today;
            var result = from p in db.Reservas
                         where DbFunctions.TruncateTime(p.fecha) == today
                         select new Project.Models.Reserva 
                         { 
                          Reservas_Tipo=p.Reservas_Tipo, 
                          Cliente=p.Cliente, 
                          fecha=p.fecha 
                         };
    
            var r = result.ToList();
            return View(r);
        }
