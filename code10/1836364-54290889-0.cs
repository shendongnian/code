    var firstNames = new [] { lblFirstName1, lblFirstName2 , lblFirstName3 , .......... };
     
    for(int i = 0; i < names.Count; i++)
            {
                Random rand = new Random();
                int index = rand.Next(names.Count);
                var name = names[index];
    
                firstNames[i].Text = name;
                firstNames[i].Visible = true;
                names.RemoveAt(index);
            }  
