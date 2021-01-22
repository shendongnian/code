        private string ToHex(Color color)
        {
            var r = ToHexidecimal(color.R * 255);
            var g = ToHexidecimal(color.G * 255);
            var b = ToHexidecimal(color.B * 255);
            return ColorTranslator.FromHtml(String.Format("#{0}{1}{2}", r, g, b)).Name.Remove(0, 2);
        }
        private string ToHexidecimal(double num)
        {
            byte[] bytes = BitConverter.GetBytes(num);
            var str = BitConverter.ToString(bytes);
            return str.ToUpper().Substring(str.Length - 2, 2);
        }
