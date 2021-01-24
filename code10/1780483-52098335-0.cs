    public class CottonCandy
        {
    
            public string Mass { get; set; }
            public string Volume { get; set; }
            public string TotalSugar { get; set; }
            public string Colors { get; set; }
            public string this[string key]
            {
                get
                {
                    switch (key)
                    {
                        case "Mass":
                            return this.Mass;
                        case "Volume":
                            return this.Volume;
                        case "TotalSugar":
                            return this.TotalSugar;
                        case "Colors":
                            return this.Colors;
                        default:
                            return "";
                    }
    
                }
                set
                {
                    switch (key)
                    {
                        case "Mass":
                            this.Mass = value; break;
                        case "Volume":
                            this.Volume = value; break;
                        case "TotalSugar":
                            this.TotalSugar = value; break;
                        case "Colors":
                            this.Colors = value; break;
                        default:
                            break;
                    }
                }
            }
    
    
        }
