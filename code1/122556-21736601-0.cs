        public static System.Drawing.Color GetColorFromHexValue(string hex)
        {
            string cleanHex = hex.Replace("0x", "").TrimStart('#');
            if (cleanHex.Length == 6)
            {
                //Affix fully opaque alpha hex value of FF (225)
                cleanHex = "FF" + cleanHex;
            }
            int argb;
            if (Int32.TryParse(cleanHex, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out argb))
            {
                return System.Drawing.Color.FromArgb(argb);
            }
            //If method hasn't returned a color yet, then there's a problem
            throw new ArgumentException("Invalid Hex value. Hex must be either an ARGB (8 digits) or RGB (6 digits)");
        }
