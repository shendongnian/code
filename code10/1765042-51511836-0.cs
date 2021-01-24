    List<string> LinesToWrite = new List<string>();
    foreach (string line in File.ReadLines("matriculasSemDV.txt"))
    {
         // Your logic here
         string rest_div_hex = rest_div.ToString("X");
         string matricula_conc = line + "-" + rest_div_hex;
         LinesToWrite.Add(matricula_conc);
    }
    string path = "matriculasComDV.txt";
    File.WriteAllLines(path, LinesToWrite , Encoding.UTF8);
