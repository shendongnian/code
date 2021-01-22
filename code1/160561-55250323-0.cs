        static void convertToBinary(int n)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(n);
            // step 1 : Push the element on the stack
            while (n > 1)
            {
                n = n / 2;
                stack.Push(n);
            }
            // step 2 : Pop the element and print the value
            foreach(var val in stack)
            {
                Console.Write(val % 2);
            }
         }
