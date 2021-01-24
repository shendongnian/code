    Contract currentContract = new Contract
        {
            ID = string.IsNullOrEmpty(ID) ? 0 : int.Parse(ID),
            PartName = partNumber,
            PartPrice = string.IsNullOrEmpty(contractPrice) ? 0 : 
            Decimal.Parse(contractPrice),
            StartDate = contractStart,
            EndDate = contractEnd,
            CustomerNumber = customerNumber,
            Notes = notes
        };
