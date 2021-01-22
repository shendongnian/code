    /// <summary>
    /// Author: Ben Maddox
    /// </summary>
    public class ZBase32Encoder
    {
        /*
         * Accepted characters based on code from: 
         * http://www.codeproject.com/KB/recipes/Base32Encoding.aspx?display=Print
         */
        public const string AcceptedCharacters = "ybndrfg8ejkmcpqxot1uwisza345h769";
        public static string Encode(int input)
        {
            string result = "";
            if (input == 0)
            {
                result += AcceptedCharacters[0];
            }
            else
            {
                while (input > 0)
                {
                    //Must make sure result is in the correct order
                    result = AcceptedCharacters[input%AcceptedCharacters.Length] + result;
                    input /= AcceptedCharacters.Length;
                }
            }
            return result;
        }
        public static int Decode(string input)
        {
            var inputString = input.ToLower();
            int result = 0;
            for (int i = 0; i < inputString.Length; i++)
            {
                result *= AcceptedCharacters.Length;
                var character = inputString[i];
                result += AcceptedCharacters.IndexOf(character);
            }
            return result;
        }
        public static int Decode(char data)
        {
            return Decode(data.ToString());
        }
    }
