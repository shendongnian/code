    static void Main(string[] args)
    {
        Stack st = new Stack();
        Add(st);
        StackOperation(st);
    }
    static void StackOperation(Stack st)
    {
        string act = string.Empty;
        while (act != "Q")
        {
            act = DisplayPrompt();
            switch (act)
            {
                case "A":
                    Add(st);
                    break;
                case "D":
                    Remove(st);
                    break;
                case "V":
                    View(st);
                    break;
                case "Q":
                    break;
                default:
                    Console.WriteLine("Not a valid option");
                    break;
            }
        }
    }
    static string DisplayPrompt()
    {
        Console.WriteLine();
        Console.WriteLine("A to Add");
        Console.WriteLine("D to Pop");
        Console.WriteLine("V to View");
        Console.WriteLine("Q to Quit");
        var act = Console.ReadKey().KeyChar;
        Console.WriteLine();
        return act.ToString();
    }
    static void Add(Stack st)
    {
        Console.Write("Input item to add to stack: ");
        int inp = Convert.ToInt32(Console.ReadLine());
        st.Push(inp);
    }
    static void Remove(Stack st) { Console.WriteLine("Delete item from Stack"); }
    static void View(Stack st) { Console.WriteLine("View Stack"); }
