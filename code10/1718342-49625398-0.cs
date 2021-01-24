    private void Form2_Load(object sender, EventArgs e)
            {
                string input = "Lnnnai";
                bool foundInDatabase = false;
                //set your value after db query
                if (foundInDatabase)
                { }//your code here
                else
                { 
                    string s = input.Substring(input.Length - 1, 1);
                    s = IncrementCharacter(s);
                    Debug.Print(s);
                    string newString  = input.Remove(input.Length - 1, 1);
                    newString += s;
                    Debug.Print(newString);
                }
            }
     private string IncrementCharacter(String character)
            {
                int code = Char.ConvertToUtf32(character,0);
                switch (code)
                {
                    case 57:
                        return "A";
                    case 90:
                        return "a";
                    default:
                        code += 1;
                        return ((char)code).ToString();
                }
            }
