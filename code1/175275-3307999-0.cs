    List<string> lines = File.ReadAllLines(@"filename.txt").ToList();
    if(lines.Count>lineNum){
       lines.RemoveAt(lineNum);
    }
    File.WriteAllLines(@"filename.txt",lines.ToArray());
