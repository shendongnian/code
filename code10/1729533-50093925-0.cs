    public int IndexOf(string text)
            {
    
                for (Node i = Head; i != null; i = i.Next)
                {
                    int counter = 0;
                    Console.WriteLine("Value of counter = "+ counter);
                    if (text == i.Text)
                    {
                        return counter;
                    }
    
                    counter++;
                    Console.WriteLine("Value of counter post increment = "+ counter);
                }
                return -1;
            }
