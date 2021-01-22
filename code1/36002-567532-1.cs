    public void Test() {
        Box<int> number = new Box<int>(10);
        Box<string> text = new Box<string>("PRINT \"Hello, world!\"");
        Console.Write(number);
        Console.Write("    ");
        Console.WriteLine(text);
        
        F1(number, text);
        Console.Write(number);
        Console.Write("    ");
        Console.WriteLine(text);
        Console.ReadKey();
    }
    void F1(Box<int> number, Box<string> text) {
        number.Value = 10;
        text.Value = "GOTO 10";
    }
