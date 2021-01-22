        public List<MailAddress> ParseAddresses(string field)
        {
            var tokens = field.Split(',');
            var addresses = new List<string>();
            var tokenBuffer = new List<string>();
            foreach (var token in tokens)
            {
                tokenBuffer.Add(token);
                if (token.IndexOf("@", StringComparison.Ordinal) > -1)
                {
                    addresses.Add( string.Join( ",", tokenBuffer));
                    tokenBuffer.Clear();
                }
            }
            
            return addresses.Select(t => new MailAddress(t)).ToList();
        }
