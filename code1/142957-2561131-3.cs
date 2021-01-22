    public override List<ITieneID> Buscar(ITieneID elementoPatron) 
    { 
            return new List<ITieneID>(base.Repository.Context.Areas
                  .Where(a=>a.areaID == elementoPatron.ID || a.areaDescripcion.Contains(elementoPatron.Descripcion))
                  .Cast<ITieneID>()); 
    }
