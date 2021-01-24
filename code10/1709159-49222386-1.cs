    for (int i = 0; i < Speelveld.Count; i++)
    {
        for (var element = 0; element < Speelveld[i].Count; element++)
        {
            if (Speelveld[i][element] != Speelveld[i][5])
            {
                if (Speelveld[i][element].GetType() == typeof(Herbivoor) && Speelveld[i][element + 1].GetType() == typeof(LeegOrganisme))
                {
    
                    intStap = r.Next(4);
                    Console.WriteLine("Rechts leeg");
                    //Controleer of het te checken item niet het als eerste in de lijst staat
    
                     if(Speelveld[i][element] != Speelveld[i][0])
                     {
                     //check range waarin de herbivoor zich kan voortbewegen
    
                         if(Speelveld[i][element - 1].GetType() == typeof(LeegOrganisme))
                         {
                             Console.WriteLine("Links leeg");
                             links = true;
                         }
                                    
                         if(Speelveld[i-1][element].GetType() == typeof(LeegOrganisme))
                         {
                             Console.WriteLine("Boven leeg");
                         }
                    }
                }
            }
        }
    }
