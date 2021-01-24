    public class RepositorioEmpresa : BaseRepositorio, IRepositorio<Empresa>
    {
        public RepositorioEmpresa(IDbConnection connection): base(connection)
        {
        }
    } 
