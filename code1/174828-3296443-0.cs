        else 
        {
            Queue<Packet> ourQueue = new Queue<Packet>();  //this doesn't need to be concurrent unless you want it to be for some other reason.
            Packet p;
            while(_packetQueue.TryDequeue(out p))
            {
                ourQueue.Enqueue(p);
            }
            Console.WriteLine("BackgroundThread: ourQueue.Count is {0}", ourQueue.Count);
        }
