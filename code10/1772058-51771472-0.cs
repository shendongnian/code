    using System.Linq;
    ...
    foreach(var item in Turno)
    {
        foreach(var ite in DocenteId)
        {
            if (!turnodecente.Any(x => x.TurnoId == item.TurnoId && x.DocenteId == ite))
            {
                turnodocente.Add(new TurnoDocente
                {
                    TurnoId = item.TurnoId,
                    DocenteId = ite
                });
            }
        }
    }
