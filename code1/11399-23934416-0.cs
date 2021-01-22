            ArrayList results;
            try
            {
                var queryString = @"EXEC " + StoredProcedureName;
                foreach (var consulta in Consultas)
                {
                    switch (consulta.tipoCampo)
                    {
                        case Consulta.TipoCampo.dato:
                            queryString = queryString + " " + consulta.Campo + " = " + "'" + consulta.Valor + "'";
                            break;
                        case Consulta.TipoCampo.numero:
                            queryString = queryString + " " + consulta.Campo + " = " + consulta.Valor;
                            break;
                    }   
                    queryString = queryString + ",";
                }
                queryString = queryString.Remove(queryString.Count() - 1, 1);
                var query = new HqlBasedQuery(typeof(T),QueryLanguage.Sql, queryString);
                results = (ArrayList)ActiveRecordMediator.ExecuteQuery(query);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return results;
        }
    public class Consulta
    {
        public enum TipoCampo
        {
            dato,
            numero
        }
        public string Campo { get; set; }
        public TipoCampo tipoCampo { get; set; }
        public string Valor { get; set; }
        public string Indicador { get; set; }
    }
    public void _Pruebastp()
        {
            var p = new Recurso().DevolverCamposDeObjetoSTP(
                                                             new Recurso(),
                                                             new List<Consulta> { new Consulta { Campo = "@nombre", tipoCampo = Consulta.TipoCampo.dato, Valor = "chr" }, new Consulta { Campo = "@perfil", tipoCampo = Consulta.TipoCampo.numero, Valor = "1" } },
                                                             "Ejemplo");
        }
`
