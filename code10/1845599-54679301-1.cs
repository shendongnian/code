    private bool CanPlace(int x, int y, int size, bool horizontal)
    {
        if (horizontal)
        {
            for (int x = 0; x < size; x++)
            {
                if (SeaButtons[firstNum + x, secondNum].Tag != null)
                {
                    return false;
                }
            }
        }
        else
        {
            //same as above
        }
        return true;
    }
    private void HideShips() // method to hide the ships in the buttons
    {
        foreach(Ship s in AllShips)
        {
            //pick 2 random numbers
            int firstNum = rnd.Next(0, (19 - s.Size)); // game board is 20x20
            int secondNum = rnd.Next(0, (19 - s.Size));
            int rando = rnd.Next(0, 100);
            while (!CanPlace(firstNum, secondNum, s.Size, rando > 50)
            {
                firstNum = rnd.Next(0, (19 - s.Size));
                secondNum = rnd.Next(0, (19 - s.Size));
                rando = rnd.Next(0, 100);
            }
            //decides horizontal/vertical at random
            if (rando > 50)
            {
                //horizontal
                for (int x = 0; x < s.Size; x++)
                {
                    SeaButtons[firstNum + x, secondNum].Tag = s;
                }
            }
            else
            {
                //vertical
                for (int x = 0; x < s.Size; x++)
                {
                    SeaButtons[firstNum, secondNum + x].Tag = s;
                }
            }
        }
    }
