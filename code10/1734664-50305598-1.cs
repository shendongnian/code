    /// <summary>
    /// A datasoure that provides access to trade grid data items
    /// </summary>
    internal class TradeGridDatasorce: ObjectDataSource<TSContract>
    {
        readonly ContractRepository rep;
    
        public TradeGridDatasorce()            
        {
            rep = ContractRepository.Instance;
    
            Parallel.ForEach(rep.Values, (contract) => {
                contract.OnEnteredTradeGrid += Contract_OnEnteredTradeGrid;
                contract.OnLeftTradeGrid += Contract_OnLeftTradeGrid;
    
    
                if (contract.State.IsSet(ContractStates.IsInAnTransaction))
                {
                    base.Add(contract);
                    base.OnAddingNew(new System.ComponentModel.AddingNewEventArgs(contract));
                }
                rep.OnAdd += Rep_OnAdd;
            });
        }
    ...
    
    }
