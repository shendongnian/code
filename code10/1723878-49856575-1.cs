    [OnDeserialized()]
    internal void OnDeserializedMethod(StreamingContext context)
    {
         foreach(var term in TransferTerms)
         {
               term.TargetWarehouseGuid = this.Guid;
         }
    }
