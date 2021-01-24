            ClientEx client= new ClientEx();
            
            await client.WaitForServerAsync(ip, port);
            
            string msg = string.Empty;
            do
            {
                Console.Write("Send Message: ");
                msg = Console.ReadLine();
                shell.Send(msg);
            } while (msg != "q");
            Console.WriteLine();
            Console.WriteLine("BYE");
            Console.ReadKey();
