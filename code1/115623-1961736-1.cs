    string[] lines = File.ReadAllLines("file1.txt");
    foreach (string line in lines)
    {
        File.WriteAllText(line + textbox1.Text + ".txt",
                          textbox2.Text + line + textbox1.Text);
    }
