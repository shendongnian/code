    var TransactionList = context.Trx
                    .GroupBy(t => t.BatchId)    //group by BatchId
                    .OrderBy(t => t.Key)        //order by BatchId
                    .Select
                    (g =>
                        //Create a new "Batch Group" anonymously where each batch contains the associated transactions
                        new
                        {
                            BatchId = g.Key,
                            BatchTransactions = g.Select(trx => new { Card = trx.Card, User = trx.User }).OrderByDescending(batchTrx => batchTrx.Card.CardId),    //order by CardId
                        }
                    );
