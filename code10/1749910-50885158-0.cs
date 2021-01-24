        while (true)
        {
            try
            {
                var entry = Console.ReadLine();
                List<int> myNumbers = entry.Split(',').Select(int.Parse).ToList();
                serializedValue = _unitOfWork.GetSerializedCollection(myNumbers);
                Console.WriteLine(serializedValue);
                Console.ReadLine();
            }
            catch (FormatException)
            {
                Console.Write("You must enter a  number.");
                continue;
            }
            break;
        }
