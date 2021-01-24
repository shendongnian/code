        string current_folder = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName; // get gurrent folder if the file is in the same dir as the .exe app 
        string full_path = Path.Combine(current_folder, "test.txt"); // specify the same of the file
        string[] stored = System.IO.File.ReadAllLines(full_path).Where(line => !string.IsNullOrWhiteSpace(line)).Distinct().ToArray(); // read the file into a string array with removing the duplicates and empty lines
        comboBox1.Items.AddRange(stored); // finally fill in the combobox with the array
        // you can skip current folder and full path and directly specify the location of the file 
        string text = System.IO.File.ReadAllText(@"C:\Users\Public\TestFolder\WriteText.txt");
