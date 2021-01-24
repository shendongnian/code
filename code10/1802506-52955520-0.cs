    //removing item from array without deleting the position
    						Console.WriteLine("number of element BEFORE deleting in array {0}", cities.Count());
    						Console.WriteLine("please enter the position of the element that you want to delete:");
    						int numToRemove = Convert.ToInt32(Console.ReadLine());
    						for (int j = 0; j < cities.Length-1; j++)
    						{
    							if (j >= numToRemove)
    							{
    								cities[j] = cities[j + 1];
    							}
    						}
    						Console.WriteLine("number of element AFTER deleting in array {0}", cities.Count());
