    public List<Tto> Serialize<Tfrom, Tto>(
        IEnumerable<IFinalOutput> outputTableCompositeViewModel)
    {
       List<Tto> sourceSystemDTOList = new List<Tto>();       
       foreach (var item in outputTableCompositeViewModel)
       {
        Tto outputItem = new Tto();              
        var outputTableItem = item.MainOutput;       
        var supportTableItem = item.SupportOuput;
        var calculatedTableItem = item.CalcOutput;
        outputItem = Mapper.Map<Tto>(outputTableItem)
                                            .Map(calculatedTableItem)
                                            .Map(supportTableItem);
        sourceSystemDTOList.Add(outputItem);
       }
      return new List<Tto>(sourceSystemDTOList);
    }
