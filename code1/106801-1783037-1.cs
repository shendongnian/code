        static void Main(string[] args)
        {
            var elements = XElement
                .Load("test.xml")
                .XPathSelectElements("//media/media-object[@encoding='base64']");
            foreach (XElement element in elements)
            {
                var image = AnotherDecode64(element.Value);
            }
        }
        static byte[] AnotherDecode64(string base64Decoded)
        {
            string temp = base64Decoded.TrimEnd('=');
            int asciiChars = temp.Length - temp.Count(c => Char.IsWhiteSpace(c));
            switch (asciiChars % 4)
            {
                case 1:
                    //This would always produce an exception!!
                    //Regardless what (or what not) you attach to your string!
                    //Better would be some kind of throw new Exception()
                    return new byte[0];
                case 0:
                    asciiChars = 0;
                    break;
                case 2:
                    asciiChars = 2;
                    break;
                case 3:
                    asciiChars = 1;
                    break;
            }
            temp += new String('=', asciiChars);
            return Convert.FromBase64String(temp);
        }
