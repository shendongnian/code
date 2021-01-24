    [HttpGet("filtrar")]
    public ActionResult<List<TipoDocumento>> GetAllPorFiltro(string sigla, int? status, string descricao)
    {
         var res = _tipoDocumentoRepositorio
            .GetAll()
            .WhereIf(!String.IsNullOrEmpty(sigla), q => q.sigla == sigla)
            .WhereIf(status.HasValue, q => q.sigla == sigla.Value)
            .WhereIf(!String.IsNullOrEmpty(descricao), q => q.descricao == descricao)
            .ToList();
         ...
    }
