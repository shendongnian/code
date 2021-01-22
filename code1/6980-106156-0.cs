            IAsyncResult result = command.BeginExecuteNonQuery();
            int count = 0;
            while (!result.IsCompleted)
            {
                Console.WriteLine("Waiting ({0})", count++);
                System.Threading.Thread.Sleep(1000);
            }
            Console.WriteLine("Command complete. Affected {0} rows.",
            command.EndExecuteNonQuery(result));
