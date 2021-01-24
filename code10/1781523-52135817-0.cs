    static async Task RepeadtReadingXml(int delayMillis, int repeatMillis, CancellationToken ct)
        {
            Console.WriteLine("{0}: Start reading xml file", DateTime.Now);
            await Task.Delay(delayMillis, ct);
            while (true)
            {
                Console.WriteLine("{0}: Reading xml file every 1 sec", DateTime.Now);
                //***************************************************//
                //     Add you logic to read your xml file here      //
                //***************************************************//
                await Task.Delay(repeatMillis, ct);
            }
        }
