            // Only one cast here
            Enumerator<DSTransactions.TransactionsRow> enumer = (IEnumerator<DSTransactions.TransactionsRow>)dv.GetEnumerator();
            while (enumer.MoveNext())
            {
                // enumer.Current will be of type DSTransactions.TransactionsRow
                Console.WriteLine(enumer.Current);
            }
            enumer.Dispose();
