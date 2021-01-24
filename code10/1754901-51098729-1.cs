            static string ToBinary(int input)
            {
                string[] binary = { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111" };
                return string.Join("", input.ToString("x").Select(x => binary[byte.Parse(x.ToString(), System.Globalization.NumberStyles.HexNumber)]));
            }
