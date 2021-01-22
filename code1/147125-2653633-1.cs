    void TestInvokeWithParams() {
        Func<string[], bool> f = WriteLines;
        
        int result1 = f.InvokeWithParams("abc", "def", "ghi"); // returns 3
        int result2 = f.InvokeWithParams(null); // returns 0
    }
    int WriteLines(params string[] lines) {
        if (lines == null)
            return 0;
            
        foreach (string line in lines)
            Console.WriteLine(line);
            
        return lines.Length;
    }
