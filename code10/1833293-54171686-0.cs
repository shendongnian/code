    using System.Collections.Generic;
    
    var peopletiles = new List<TextBox>{ A2, A3, A4, A5,};
    Random random = new Random();
    for (var i = 0; i < Edit.peopleStar; i++)
    {
        var index = random.Next(0, peopletiles.Length);
        peopletiles[index].BackColor = Color.Purple;
        peopletiles.RemoveAt(index);
    }
 
