        public string GeneratePassword(int len)
        {
            string res = "";
            Random rnd = new Random();
            while (res.Length < len) res += (new Func<Random, string>((r) => {
                char c = (char)((r.Next(123) * DateTime.Now.Millisecond % 123)); 
                return (Char.IsLetterOrDigit(c)) ? c.ToString() : ""; 
            }))(rnd);
            return res;
        }
