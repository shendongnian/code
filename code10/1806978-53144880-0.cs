    string[] nameArray = new string[] { "Tyler", "Kyle", "Roger", "Rick" };
    // Input.
    Console.WriteLine(String.Format("Select an item from the array using numbers {0}-{1}", 0, nameArray.Length));
    string selectedIndexString = Console.ReadLine();
    // Processing.
    int selectedIndex = Convert.ToInt32(selectedIndexString);
    if (selectedIndex < 0 || selectedIndex >= nameArray.Length)
    {
        throw new ArgumentException(String.Format("The index must belong to the range: [{0}:{1}]", 0, nameArray.Length));
    }
    string selectedString = nameArray[selectedIndex];
    // Output.
    Console.WriteLine(String.Format("You have choosen: {0}", selectedString));
