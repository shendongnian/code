    public BindingList<Builders> GetListBuilders()
        {
            BindingList<Builders> builderList = new BindingList<Builders>();
            var ctx = new IWMJEntities();
            var query = (from l in ctx.tblBuilders
                         select new Builders
                         {
                             ID = l.BuilderID,
                             Projeto = l.NomeProjeto,
                             Status = l.Status,
                             DataPedido = l.DataPedido,
                             DataPendente = l.DataPendente,
                             DataEntregue = l.DataEntregue,
                             DataAnulado = l.DataAnulado,
                             Dias = l.GetBusinessDays()
                         });
            foreach (var list in query)
                builderList.Add(list);
            return builderList;
        }
