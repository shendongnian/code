    string textbox1string = textbox1.Text, textbox2string = textbox2.Text;
    foreach(string line in File.ReadAllLines("data.txt")) {
        string path = Path.ChangeExtension(line + textbox1string, "txt");
        File.WriteAllText(path, textbox2string  + line + textbox1string);
    }
