    public class Maths
    {
        public Maths() { }
        public Double Add(Double numberOne, Double numberTwo)
        {
            return numberOne + numberTwo;
        }
    }
    
    public class Alphabet
    {
        public Alaphabet() { }
        public String Add(Char characterOne, Char characterTwo)
        {
            return characterOne.ToString() + characterTwo.ToString();
        }
    
    }
    
    public void Main()
    {
        Alphabet alaphatbet = new Alphabet();
        String alphaAdd = alphabet.Add('a', 'b'); // Gives "ab"
        
        Maths maths = new Maths();
        Double mathsAdd = maths.Add(10, 5); // Gives 15
    }
