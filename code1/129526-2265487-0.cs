            string test ="ImageSizeTest";
            
            string pattern = "[A-Z]";
            Regex AllCaps = new Regex(pattern);                       
            var fs = test.ToCharArray().Select(x =>
            {
                if (AllCaps.IsMatch(x.ToString()))
                    return " " + x.ToString();
                return x.ToString();
            }).ToArray();
            var resss =string.Join("",fs).Trim();
