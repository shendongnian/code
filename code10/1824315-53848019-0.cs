    else if (number == 5)
    {
        Console.Write("Student's index: ");
        var success = int.TryParse(Console.ReadLine(), out int index1);
        if (success)
        {
            //next logic here if the input is an integer
			try
            {
				customDataList.FindStudent(index1); //displays the element that has the specified index
			}
			catch (ArgumentOutOfRangeException)
			{
				Console.WriteLine("Please choose an index from 0 to 9!");
			}
        }
        else
        {
            //do something when the input is not an integer
        }
    }
