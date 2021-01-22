     int[] array = {4,5,7,1,8};           
    
                int n1, n2;
                bool stillgoing = true;
    
                while (stillgoing)
                {
                    stillgoing = false;
                    for (int i = 0; i < (array.Length-1); i++)
                    {                  
                        if (array[i] > array[i + 1])
                        {
                            n1 = array[i + 1];
                            n2 = array[i];
    
                            array[i] = n1;
                            array[i + 1] = n2;
                            stillgoing = true; 
                        }
                    }
                }
                for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine(array[i]);
                }
