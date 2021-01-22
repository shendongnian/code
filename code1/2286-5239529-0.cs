        public static string CleanInvalidXmlChars( string Xml, string XMLVersion )
        {
            string pattern = String.Empty;
            switch( XMLVersion )
            {
                case "1.0":
                    pattern = @"&#x((10?|[2-F])FFF[EF]|FDD[0-9A-F]|7F|8[0-46-9A-F]9[0-9A-F]);";
                    break;
                case "1.1":
                    pattern = @"&#x((10?|[2-F])FFF[EF]|FDD[0-9A-F]|[19][0-9A-F]|7F|8[0-46-9A-F]|0?[1-8BCEF]);";
                    break;
                default:
                    throw new Exception( "Error: Invalid XML Version!" );
            }
            Regex regex = new Regex( pattern, RegexOptions.IgnoreCase );
            if( regex.IsMatch( Xml ) )
                Xml = regex.Replace( Xml, String.Empty );
            return Xml;
        }
