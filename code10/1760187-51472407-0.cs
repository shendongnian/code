    var transactionHashes = new List<string>();
    foreach(var recepient in recepients){
    
                var transactionInput = new TransactionInput
                {
                    From = account.Address,
                    GasPrice = Web3.Convert.ToWei(1.5, UnitConversion.EthUnit.Gwei);,
                    To = recipient.Address,
                    Value = new HexBigInteger(new BigInteger(recipient.Value)),
                };
         var transactionHash = web3.Eth.TransactionManager.SendTransactionAsync(transactionInput);
         transanctionHashes.Add(transactionHash);
    }
