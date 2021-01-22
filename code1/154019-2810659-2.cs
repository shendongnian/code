    namespace Fragments
    {
        class Fragment
        {
            private readonly static Regex Pattern =
                new Regex(@"^(?<Letter>[A-Z]{1})(?<Number>.+)$");
    
            public readonly string Text;
            public readonly bool IsMatch;
    
            public readonly char Letter;
            public readonly double Number;
    
            public Fragment(string text)
            {
                this.Text = text;
                Match match = Fragment.Pattern.Match(text);
                this.IsMatch = match.Success;
    
                if (match.Success)
                {
                    this.Letter = match.Groups["Letter"].Value[0];
                    string possibleNumber = match.Groups["Number"].Value;
    
                    double parsedNumber;
                    if (double.TryParse(possibleNumber, out parsedNumber))
                    {
                        this.Number = parsedNumber;
                    }
                    else
                    {
                        Debug.WriteLine("Couldn't parse double from input {0}", possibleNumber);
                    }
                }
                else
                {
                    Debug.WriteLine("Fragment {0} did not match fragment pattern", text);
                }
            }
    
            public Fragment(char letter, double number)
            {
                this.Letter = letter;
                this.Number = number;
                this.Text = letter + number.ToString();
                this.IsMatch = true;
            }
    
            public override string ToString()
            {
                return this.Text;
            }
        }
    }
