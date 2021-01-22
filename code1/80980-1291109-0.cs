    public class RGVCAFAC
        {
            public int index { get; set; }
            public string CODEAUX { get; set; }
    
            public string FECRGV { get; set; }
            public string TDORGV { get; set; }
            public string MONRGV { get; set; }
            public string NDORGV { get; set; }
            public string RUCCLI { get; set; }
            public string RAZCLI { get; set; }
            public string CDCRGV { get; set; }
            public string TERRGV { get; set; }
            public string PDSRGV { get; set; }
            public double VVTRGVS { get; set; }
            public double IGVRGVS { get; set; }
            public double TOTRGVS { get; set; }
            public string TCARGV { get; set; }
            public double VVTRGVD { get; set; }
            public double IGVRGVD { get; set; }
            public double TOTRGVD { get; set; }
            public string PACEST { get; set; }
    
            public string CODUNI { get; set; }
    
            public string DIRCLI { get; set; }
            public string TELCLI { get; set; }
            public int PFLAG { get; set; }
    
    
            //I have to add the following, so generators are useless :(
    
    
            public RGVCAFAC()
            {
            }
    
            public RGVCAFAC(RGVCAFAC x)
            {
                this.CODEAUX = x.CODEAUX;
                this.FECRGV = x.FECRGV;
                this.TDORGV = x.TDORGV;
                this.MONRGV = x.MONRGV;
                this.RUCCLI = x.RUCCLI;
                this.RAZCLI = x.RAZCLI;
                this.CDCRGV = x.CDCRGV;
                this.TERRGV = x.TERRGV;
                this.PDSRGV = x.PDSRGV;
                this.VVTRGVS = x.VVTRGVS;
                this.IGVRGVS = x.IGVRGVS;
                this.TOTRGVS = x.TOTRGVS;
                this.TCARGV = x.TCARGV;
                this.VVTRGVD = x.VVTRGVD;
                this.IGVRGVD = x.IGVRGVD;
                this.TOTRGVD = x.TOTRGVD;
                this.PACEST = x.PACEST;
                this.CODUNI = x.CODUNI;
                this.DIRCLI = x.DIRCLI;
                this.TELCLI = x.TELCLI;
                this.PFLAG = x.PFLAG;
            }
        }
