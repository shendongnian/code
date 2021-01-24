     public void desactivate_Btn()
        {
            UIElement b;
            for (int i = 0; i < theGrid.Children.Count; i++)
            {
                b = theGrid.Children[i];
                if (whoPlays)
                {
                    if (((Button)b).Tag.ToString() == "White")
                    {
                        b.IsEnabled = false; // to disable all the buttons
                       selectedPawn = null; // to disable the selected button
                       t = true; // i had to put 't' true as this variable needs to be true at the beginning of my code
                    }
                    else if (((Button)b).Tag.ToString() == "Black")
                    {
                        b.IsEnabled = true;
                    }
                }
                else
                {
                    if (((Button)b).Tag.ToString() == "Black")
                    {
                        b.IsEnabled = false;
                       selectedPawn = null;
                        t = true;
                    }
                    else if (((Button)b).Tag.ToString() == "White")
                    {
                        b.IsEnabled = true;
                    }
                }
            }
        }
