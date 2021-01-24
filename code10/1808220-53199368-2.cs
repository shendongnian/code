    class Program
    {
        static void Main(string[] args)
        {
            //The LeftOf Method requires two parameters 
            //First is the string you want to examine thats LeftOf first parameter s
            string myString = "Hello World";
            //Second parameter is the char c
            char character = 'l';
            //Invoke LeftOf it will return a string format
            string result = Exenstions.LeftOf(myString, character);
            //Check the result
            Console.WriteLine(result);
            //You can also do
            //Console.WriteLine(LeftOf(mystring, character);
        }       
    }
