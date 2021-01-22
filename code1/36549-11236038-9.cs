    using System;
    using System.Collections.Generic;
    using System.Text;
    // Need to add a Reference to the System.Web assembly.
    using System.Web;
    
    namespace UriEncodingDEMO2
    {
        class Program
        {
            static void Main(string[] args)
            {
                EncodeStrings();
    
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.Read();
            }
    
            public static void EncodeStrings()
            {
                string stringToEncode = "ABCD" + "abcd"
                + "0123" + " !\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~" + "ĀāĒēĪīŌōŪū";
    
                // Need to set the console encoding to display non-ASCII characters correctly (eg the 
                //	Latin A-Extended characters such as ĀāĒē...).
                Console.OutputEncoding = Encoding.UTF8;
    
                // Will also need to set the console font (in the console Properties dialog) to a font 
                //	that displays the extended character set correctly.
                // The following fonts all display the extended characters correctly:
                //	Consolas
                //	DejaVu Sana Mono
                //	Lucida Console
    
                // Also, in the console Properties, set the Screen Buffer Size and the Window Size 
                //  Width properties to at least 140 characters, to display the full width of the 
                //  table that is generated.
    
                Dictionary<string, Func<string, string>> columnDetails =
                    new Dictionary<string, Func<string, string>>();
                columnDetails.Add("Unencoded", (unencodedString => unencodedString));
                columnDetails.Add("UrlEncoded",
                    (unencodedString => HttpUtility.UrlEncode(unencodedString)));
                columnDetails.Add("UrlEncodedUnicode",
                    (unencodedString => HttpUtility.UrlEncodeUnicode(unencodedString)));
                columnDetails.Add("UrlPathEncoded",
                    (unencodedString => HttpUtility.UrlPathEncode(unencodedString)));
                columnDetails.Add("EscapedDataString",
                    (unencodedString => Uri.EscapeDataString(unencodedString)));
                columnDetails.Add("EscapedUriString",
                    (unencodedString => Uri.EscapeUriString(unencodedString)));
                columnDetails.Add("HtmlEncoded",
                    (unencodedString => HttpUtility.HtmlEncode(unencodedString)));
                columnDetails.Add("HtmlAttributeEncoded",
                    (unencodedString => HttpUtility.HtmlAttributeEncode(unencodedString)));
                columnDetails.Add("HexEscaped",
                    (unencodedString
                        =>
                        {
                            // Uri.HexEscape can only handle the first 255 characters so for the 
                            //	Latin A-Extended characters, such as A, it will throw an 
                            //	ArgumentOutOfRange exception.						
                            try
                            {
                                return Uri.HexEscape(unencodedString.ToCharArray()[0]);
                            }
                            catch
                            {
                                return "[OoR]";
                            }
                        }));
    
                char[] charactersToEncode = stringToEncode.ToCharArray();
                string[] stringCharactersToEncode = Array.ConvertAll<char, string>(charactersToEncode,
                    (character => character.ToString()));
                DisplayCharacterTable<string>(stringCharactersToEncode, columnDetails);
            }
    
            private static void DisplayCharacterTable<TUnencoded>(TUnencoded[] unencodedArray,
                Dictionary<string, Func<TUnencoded, string>> mappings)
            {
                foreach (string key in mappings.Keys)
                {
                    Console.Write(key.Replace(" ", "[space]") + " ");
                }
                Console.WriteLine();
    
                foreach (TUnencoded unencodedObject in unencodedArray)
                {
                    string stringCharToEncode = unencodedObject.ToString();
                    foreach (string columnHeader in mappings.Keys)
                    {
                        int columnWidth = columnHeader.Length + 1;
                        Func<TUnencoded, string> encoder = mappings[columnHeader];
                        string encodedString = encoder(unencodedObject);
    
                        // ASSUMPTION: Column header will always be wider than encoded string.
                        Console.Write(encodedString.Replace(" ", "[space]").PadRight(columnWidth));
                    }
                    Console.WriteLine();
                }
            }
        }
    }
