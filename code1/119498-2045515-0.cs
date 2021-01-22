        public Int32 ChooseNextColor(Int32 numColors)
        {
            var success = false;
            while (!success)
            {
                Console.Write("Please enter your next color selection: ");
                int nextColor;
                success = int.TryParse(Console.ReadLine(), out nextColor);
                
                if (success && nextColor > 0 && nextColor < numColors) return nextColor;
                Console.WriteLine("Unrecognized input: " + Console.ReadLine());
                Console.WriteLine("Please enter a value between 0 and " + numColors + ".");
            }
            throw new ApplicationException("The thing that should not be.");
        }
