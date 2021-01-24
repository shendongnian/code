    var query = from p in Context.PapelContratos
                where p.OrigemId == id
                join g in Context.GruposCargo on new { a = p.UsuarioGrupoCargo, b = p.EmpresaId } equals new { a = g.Sigla, b = g.EmpresaId } into pg
                from g in pg.DefaultIfEmpty()
                group new { p, g } by new { p.PaisId, p.EmpresaId, p.Codigo, p.Nome, p.OrigemId } into pg_g
                select new HierarquiaDto {
                    PaisId = pg_g.Key.PaisId,
                    EmpresaId = pg_g.Key.EmpresaId,
                    Codigo = pg_g.Key.Codigo,
                    Nome = pg_g.Key.Nome,
                    OrigemId = pg_g.Key.OrigemId.Value,
                    IsPendente = pg_g.First().p.IsPendente,
                    Usuarios = pg_g.Select(pg => new HierarquiaUsuarioSimplesDto {
                        PapelId = pg.p.PapelId,
                        HierarquiaPapelId = pg.p.HierarquiaPapelId,
                        Usuario = new HierarquiaUsuarioDto {
                            Id = pg.p.UsuarioId,
                            Nome = pg.p.UsuarioNome,
                            Matricula = pg.p.UsuarioMatricula,
                            GrupoCargo = pg.p.UsuarioGrupoCargo,
                            GrupoCargoNome = pg.g.Nome
                        }
                    }).ToList()   
                };
    var ans = query.FirstOrDefault();
