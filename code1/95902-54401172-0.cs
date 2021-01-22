    switch (mark)
            {
                case int n when n >= 80:
                    Console.WriteLine("Grade is A");
                    break;
                case int n when n >= 60:
                    Console.WriteLine("Grade is B");
                    break;
                case int n when n >= 40:
                    Console.WriteLine("Grade is C");
                    break;
                default:
                    Console.WriteLine("Grade is D");
                    break;
            }
