     public void GetPdu()
        {
            Console.WriteLine(_messageString);
            Regex regex = new Regex("^([0-9A-F]+\r)$");
            Match match = regex.Match(_messageString);
            if (match.Success)
            {
                Console.WriteLine("Match: " + match.Value);
                string messagePdu = match.Value;
                ParseMessage(messagePdu);
            }
        }
