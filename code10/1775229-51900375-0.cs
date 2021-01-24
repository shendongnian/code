    public static int GetBusinessDays(this Builders builder) // or type of ctx.tblBuilders if not the same
    {
      if (builder == null) return 0;
    
      switch(builder.status)
      {
        case "Recebido": return GetBusinessDays(builder.DataPedido, DateTime.Now);
        case "Pendente": return GetBusinessDays(builder.DataPedido, (DateTime)builder.DataPendente);
        case "Entregue": return GetBusinessDays(builder.DataPedido, (DateTime)builder.DataEntregue);
        case "Anulado": GetBusinessDays(builder.DataPedido, (DateTime)builder.DataAnulado);
        default: return 0;
      }
    }
