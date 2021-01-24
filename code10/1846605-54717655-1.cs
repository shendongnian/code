    private static void Main()
    {
        var history = new History();
        while (true)
        {
            Console.Write("Enter new page to visit, [b]ack, [f]orward, or [p]rint: ");
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) continue;
            switch (input.ToLower())
            {
                case "b":
                case "back":
                    history.MoveBackwards();
                    break;
                case "f":
                case "forward":
                    history.MoveForwards();
                    break;
                case "p":
                case "print":
                    history.PrintHistory();
                    break;
                default:
                    history.VisitNewPage(input);
                    break;
            }
        }
    }
