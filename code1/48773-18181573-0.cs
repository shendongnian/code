    public void Permutations(string input, StringBuilder sb)
        {
            if (sb.Length == input.Length)
            {
                Console.WriteLine(sb.ToString());
                return;
            }
            char[] inChar = input.ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                if (!sb.ToString().Contains(inChar[i]))
                {
                    sb.Append(inChar[i]);
                    Permutations(input, sb);    
                    RemoveChar(sb, inChar[i]);
                }
            }
        }
    private bool RemoveChar(StringBuilder input, char toRemove)
        {
            int index = input.ToString().IndexOf(toRemove);
            if (index >= 0)
            {
                input.Remove(index, 1);
                return true;
            }
            return false;
        }
