    var deptTransactionsCount = transactions.Join(
                transactionProducts, 
                transaction => transaction.Id, tp => tp.TransactionId,
                    (tran, tranProd) => new
                    {
                        tran.Id,
                        tranProd.DepartmentId
                    })
                .GroupBy(arg => new { arg.Id, arg.DepartmentId })
                .GroupBy(grouping => grouping.Key.DepartmentId)
                .ToList()
                .Count;
