    int[] numbers = new int[3];
    
    numbers[0] = 001;
    numbers[1] = 002;
    numbers[2] = 123;
    
    String displayed_Number;
            for (int i = 0; i < numbers.Length; i++)
            {
                displayed_Number = numbers[i].ToString();
                
                if (displayed_Number.Length == 3)
                {
                    listBox.Items.Add(displayed_Number);
                }
                else if (displayed_Number.Length < 3)
                {
                    while (displayed_Number.Length < 3)
                    {
                        displayed_Number = "0" + displayed_Number;
                    }
                    listBox.Items.Add(displayed_Number);
                }
            }
