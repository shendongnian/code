    public static int GetNumber() {
        boolean done = false;
        int value;
        while ( !done ) {
            Console.WriteLine("Please enter the integer: ");
            try {
                value = Convert.ToInt32(Console.ReadLine());
                done = true;
            }
            catch {
                Console.WriteLine("Please enter an integer not a character");
            }
        }
    }
