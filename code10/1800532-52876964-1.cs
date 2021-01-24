    public partial class OrificeCertPoint
    {
        public string Total { get; set; }
        public string Raw { get; set; }
        public string Flow { get; set; }
        public string Diff { get; set; }
        public string Background { get; set; }
    
        public static OrificeCertPoint CreateFrom(Temp_OrificeCertPoint copyPoint)
        {
            return new OrificeCertPoint
            {
                Total = copyPoint.Total,
                Raw = copyPoint.Raw ,
                Flow = copyPoint.Flow,
                Diff = copyPoint.Diff,
                Background = copyPoint.Background  
            };
        }
    }
