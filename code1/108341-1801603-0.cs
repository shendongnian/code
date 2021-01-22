    public void MyRecursiveFunction(List<string> files, int depth)
    {
        files.Add("...");
        if (depth < 10)
        {
            MyRecursiveFunction(files, depth + 1);
        }
    }
