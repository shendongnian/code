    private void txtAttrName_KeyDown(object sender, KeyEventArgs e)
            {
                Console.WriteLine(e.Key.ToString());
                char parsedCharacter = ' ';
                if (Char.TryParse(e.Key.ToString(), out parsedCharacter))
                {
                    Console.WriteLine((int) parsedCharacter);
                }
            }
