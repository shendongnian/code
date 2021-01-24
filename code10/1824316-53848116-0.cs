    else if (number == 5)
    {
        Console.Write("Student's index: ");
        
        try
        {
            int index1 = int.Parse(Console.ReadLine());
            customDataList.FindStudent(index1); //displays the element that has the specified index
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an index from 0 to 9!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Error: Index must be a number.");
        }
    }
