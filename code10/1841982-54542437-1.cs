    static class Program
    {
        static void Main(string[] _)
        {
            var context = new VolleyballMatchSettlementContext();
            context[1] = 1;
            context[2] = 2;
            context[3] = 3;
            context[4] = 4;
            context[5] = 5;
            Console.WriteLine($"TotalPoints3Set: {context[3]}");
            foreach (var field in context.TotalPointCurrentSet)
            {
                Console.WriteLine($"{field.Key}: {field.Value}");
            }
        }
    }
