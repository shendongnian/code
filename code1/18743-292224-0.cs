            int num = 50;
            Stack<int> stack = new Stack<int>();
            while (num != 0)
            {
                stack.Push(num % 2);
                num /= 2;
            }
            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
