            String literal = "L002BO4";
            String variable = row["BarCode"].ToString();
            if (literal.Length == variable.Length)
                Debug.Print("The length of the strings match");
            else
                Debug.Print("The lengths do not match");
            Char[] variableArray = variable.ToCharArray();
            Char[] literalArray = literal.ToCharArray();
            for (int index =0; index<literalArray.Length; index++)
            {
                if (variableArray[index] == literalArray[index])
                    Debug.Print($"index {index} matches");
                else
                    Debug.Print($"index {index} does not match");
            }
