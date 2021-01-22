     if (value != 0)
            {
                var negative = value < 0;
                var s = value.ToDecimal().ToString(CultureInfo.InvariantCulture).TrimStart('-', '0');
                var i = s.IndexOf('.');
                if (i >= 0)
                {
                    s = s.Remove(i, 1);
                    if (i == 0)
                    {
                        i = s.Length;
                        s = s.TrimStart('0');
                        i = s.Length-i;
                    }
                }
                else i = s.Length;
                bytes[0] = (byte)(64 + i + (negative ? 128 : 0));
                s = s.PadRight((_size - 1) * 2, '0');
                for (var j = 1; j < _size && (j - 1) * 2 < s.Length; j++)
                    bytes[j] = byte.Parse(s.Substring((j - 1) * 2, 2), System.Globalization.NumberStyles.HexNumber);
            }
