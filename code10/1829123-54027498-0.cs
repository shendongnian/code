    using (StreamWriter w = File.AppendText(@"d:\test\names.txt"))
    {
        for (int i = 0; i < clipAnimations.Length; i++)
        {
            clipAnimations[i].name = "magic_" + name;
            string n = clipAnimations[i].name + Environment.NewLine;
            w.WriteLine(n);
        }
    }
