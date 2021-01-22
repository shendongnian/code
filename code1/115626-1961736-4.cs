    string[] lines = File.ReadAllLines("file1.txt");
    foreach (string line in lines)
    {
        string newFile = line + textbox1.Text + ".txt";
        string fileContent = textbox2.Text + line + textbox1.Text;
        File.WriteAllText(newFile, fileContent);
    }
