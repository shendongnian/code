    string[] dogs = System.IO.File.ReadAllLines(@"C:\Users\corin\Documents\C# coding\dogs.txt");
    
    int individual = totalCards / 2;
    
    Random r = new Random();
    int Cards = totalCards / 2;
    
    List<List<int>> playerCards = new List<List<int>>();
    
    //the missing piece
    for (int i = 0; i < (Cards ); i++)
    {
         playerCards.add(new List<int>()); 
    }
    
    
    for (int x = 0; x < (Cards-2); x++)
    {
        playerCards[0].Add(Int32.Parse(dogs[x]));//Cards
        playerCards[1].Add(r.Next(1, 6));//Drool
        playerCards[2].Add(r.Next(1, 101));//Exercise
        playerCards[3].Add(r.Next(1, 11));//Intelligence
        playerCards[4].Add(r.Next(1, 11));//Friendliness
    }
