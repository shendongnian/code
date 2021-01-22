    var resultado = from a in base.Repository.Context.Areas
                    where a.areaID.Equals(elementoPatron.ID) || 
                          a.areaDescripcion.Contains(elementoPatron.Descripcion)
                    select new AtlasWFM_Entities.Clases.Area
                    {
                        ID = a.areaID,
                        Descripcion = a.areaDescripcion,
                        Estado = a.areaEstado,
                    };
    return resultado.AsEnumerable() // Do the rest in LINQ to objects
                    .Select(r => new AtlasWFM_Entities.Clases.Area
                            {
                                ID = r.ID,
                                Descripcion = r.Descripcion,
                                Estado = r.Estado,
                            })
                    .ToList();
