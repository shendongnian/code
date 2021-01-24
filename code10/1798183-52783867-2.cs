    private static void DisplaySums(double lastNum) {
        double total = 0;
        Console.WriteLine("i\tSum(i)");
        for (double d = 1; d <= lastNum; d++) {
            total += (d / (d + 1));
            Console.WriteLine(d + "\t" + total);
        }
    }
