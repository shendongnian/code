            String output = "";
            int sum = 0;
            int result = 200;       //enter the "end number"
            Random r = new Random();
            while (sum != result) {
                int add;
                if ((result - sum) > 10)
                {
                    add = r.Next(1, 10);
                }
                else
                {
                    add = r.Next(result - sum + 1);
                }
                sum += add;
                output += add.ToString() + " + ";
            }
            output = output.Remove(output.Length - 2);
            Console.WriteLine(output);
