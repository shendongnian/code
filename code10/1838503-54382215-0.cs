    //Read input string
    Console.Write("Input numbers separated by space: ");
    string inputString = Console.ReadLine();
    //Split by spaces
    string[] splittedInput = inputString.Split(' ');
    //Create a list to store all valid numbers
    List<int> validNumbers = new List<int>();
    //Iterate all splitted parts
    foreach (string input in splittedInput)
    {
        //Try to parse the splitted part
        if (int.TryParse(input, out int number) == true)
        {
            //Add the valid number
            validNumbers.Add(number);
        }
    }
    //Print all valid numbers
    Console.WriteLine(string.Join(", ", validNumbers));
