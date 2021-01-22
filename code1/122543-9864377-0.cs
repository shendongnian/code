     public static string GentlyRemoveEndZeros(string input)
            {
              //  if (input == null) return null;
              //  if (input == "") return "";
                if (input.Contains(".")) return input.TrimEnd('0').TrimEnd('.');
                return input;
            }
