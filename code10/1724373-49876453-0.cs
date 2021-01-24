    catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(clNo + " Disconnected!");
            ConnUsers.Remove(clNo);
            clientsList.Remove(dataFromClient);
            foreach (var name in ConnUsers)
            {
                Console.WriteLine("Current Connected Users : " + string.Join(",", name));
            }
            //Console.WriteLine
            break;
        }
