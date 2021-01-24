    public class CursoViewModel
    { 
        public int Id {get;set;}
        public string Nome {get;set;}
        public string TipoGrau {get;set;}
    }
    [HttpGet]
    public IEnumerable<CursoViewModel> GetCurso()
    {            
        var records = _context.Curso.Include(c=>c.GrauAcademico);
        return records.Select(x=>new CursoViewModel
        {
            Id = x.Id,
            Nome = x.Nome,
            TipoGrau = x.GrauAcademico.Tipo,
        }
    }
