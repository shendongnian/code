    public class MyTestDevice: FormattedData {
        const string A0 = "A0";
        const string A2 = "A2";
        const int _rawDataLength_A0 = 256;
        const int _rawDataLength_A2 = 256;
        static readonly Dictionary<string, int> _rawDataConfigs =
            new Dictionary<string, int> {
                {A0, _rawDataLength_A0},
                {A2, _rawDataLength_A2}    
            };
        public MyTestDevice()
            : base(_rawDataConfigs) {
        }
        public string VendorName {
            get { return (ASCIIEncoding.ASCII.GetString(_rawData[A0], 20, 16)); }
            set { ;}
        }
         public bool LossOfSignal {
            get { return ((_rawData[A0][110] & 0x02) == 0x02); }
            set { ;}
        }
    }
