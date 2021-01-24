        public double? pop()
        {
            if (--position < 0)
            {
                Console.WriteLine("There are no elements in Stack");
                //I should return something here but I only want error message
                return null;
            }
            else
                return Sztos[position];
        }
