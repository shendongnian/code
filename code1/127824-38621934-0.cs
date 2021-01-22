    private static string Decode(string input, string bodycharset) {
            var i = 0;
            var output = new List<byte>();
            while (i < input.Length) {
                if (input[i] == '=' && input[i + 1] == '\r' && input[i + 2] == '\n') {
                    //Skip
                    i += 3;
                } else if (input[i] == '=') {
                    string sHex = input;
                    sHex = sHex.Substring(i + 1, 2);
                    int hex = Convert.ToInt32(sHex, 16);
                    byte b = Convert.ToByte(hex);
                    output.Add(b);
                    i += 3;
                } else {
                    output.Add((byte)input[i]);
                    i++;
                }
            }
            if (String.IsNullOrEmpty(bodycharset))
                return Encoding.UTF8.GetString(output.ToArray());
            else {
                if (String.Compare(bodycharset, "ISO-2022-JP", true) == 0)
                    return Encoding.GetEncoding("Shift_JIS").GetString(output.ToArray());
                else
                    return Encoding.GetEncoding(bodycharset).GetString(output.ToArray());
            }
        }
