    class brand
    {
        public string name;
    }
    
    class car
    {
    
        public car(string s)
        {
            Match match = Regex.Match(s, @"(?<carname>[^\.]+)\.(?<brandname>.+)");
            if (match.Success)
            {
                this.carname = match.Groups["carname"].Value;
                this.carbrand = new brand();
                this.carbrand.name = match.Groups["brandname"].Value;
            } else
            {
                throw new ArgumentException("Not a valid car");
            }
        }
    
        string carname;
        brand carbrand;
    
        public override string ToString()
        {
            return carname + "." + carbrand.name;
        }
    }
