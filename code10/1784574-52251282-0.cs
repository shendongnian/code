            string draw = "";
            string result = "";
            int counter = 0;
            int size = 4;
            while (counter < size)
            {
                counter++;
                draw += "$";
                result += draw + "\n";
            }
            Console.WriteLine("Increase $:");
            Console.WriteLine("");
            Console.WriteLine(result);
            while (counter > 0)
            {
                counter--;
                draw = draw.Remove(0, 1);
                result += draw + "\n";
            }
            Console.WriteLine("Decrease $: ");
            Console.WriteLine("");
            Console.WriteLine(result);
