    private void SearchButton_Click(object sender, RoutedEventArgs e)
    {
        Car[] allCars = new Car[] // Sample list of cars
        {
            new Car
            {
                Color = "Green",
                Make = "Ford",
                Interior = "Stone"
            },
            new Car
            {
                Color = "Green",
                Make = "Ford",
                Interior = "Wood"
            },
            new Car
            {
                Color = "Black",
                Make = "Cadillac",
                Interior = "Stone"
            },
            new Car
            {
                Color = "Black",
                Make = "Volvo",
                Interior = "Stone"
            },
            new Car
            {
                Color = "Green",
                Make = "Volvo",
                Interior = "Wood"
            },
            new Car
            {
                Color = "Green",
                Make = "Volvo",
                Interior = "Plastic"
            },
        };
        var result = _filterWithInputs(allCars); // Search the list
        SearchResultTextBlock.Text = $"Found {result.Length} matching cars."; // Output
    }
    private Car[] _filterWithInputs(IEnumerable<Car> allCars)
    {
        List<Car> result = new List<Car>();
        // Get the TextBoxes from the viow
        List<TextBox> textBoxes = new List<TextBox>();
        foreach (var mainGridChild in MainGrid.Children)
        {
            if(mainGridChild is TextBox)
                textBoxes.Add(mainGridChild as TextBox);
        }
        // Search the allCars collection.
        foreach (var car in allCars)
        {
            if (_checkCarAgainstNamedTextBoxes(car, textBoxes))
                result.Add(car);
        }
        Debug.WriteLine($"Found {result.Count} matching cars.");
        // Return the result as a fixed-size array.
        return result.ToArray();
    }
    private static bool _checkCarAgainstNamedTextBoxes(Car car, IEnumerable<TextBox> textBoxes)
    {
        foreach (TextBox textBox in textBoxes)
        {
            // Skip empty TextBokes (succees)
            if(string.IsNullOrWhiteSpace(textBox.Text))
                continue;
            var propertyName = textBox.Name.Replace("TextBox", "");
            // Assume all Car properties are strings
            var val = car.GetType().GetProperty(propertyName)?.GetValue(car) as string;
            // If the text doesn't match (case-sesitive) return false
            // No need to check any more properties after first fail.
            if (val != textBox.Text)
                return false;
        }
        return true; // Everything succeeded!
    }
