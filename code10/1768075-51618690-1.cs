    string item = TXTSearchItem.Text;
    string foods = sr.ReadToEnd(); // Maybe you already have ReadLines method here
    var lines = foods.Split(new []{ Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
    var expectedLine = lines.FirstOrDefault($"{item}-"); // assume that you have fixed format here
    if (expectedLine != null)
    {
       var splittedLine = expectedLine.Split('-');
       var foodName = splittedLine.First();
       var foodCount = splittedLine.Last();
       MessageBox.Show($"Item {foodName} is worth {footCount} SmartPoints.", "Item search", MessageBoxButtons.OK, info);
    }
    else
    {
       MessageBox.Show("Item was not found.", "Item search", MessageBoxButtons.OK, warning);
    }
    
