        protected void Page_Load(object sender, EventArgs e)
        {
            var x = GetBits("0101010111010010101001010");
        }
    
        private bool[] GetBits(string sBits)
        {
            bool[] aBits = new bool[sBits.Length];
    
            for (var i = 0; i < aBits.Length; i++)
            {
                aBits[i] = sBits[i] == '1';
            }
    
            return aBits;
        }
