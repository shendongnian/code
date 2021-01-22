     static bool IsSocketConnected(Socket s)
        {
            return !((s.Poll(1000, SelectMode.SelectRead) && (s.Available == 0)) || !s.Connected);
    
    /* The long, but simpler-to-understand version:
            bool part1 = s.Poll(1000, SelectMode.SelectRead);
            bool part2 = (s.Available == 0);
            if ((part1 && part2 ) || !s.Connected)
                return false;
            else
                return true;
            
    */
        }
