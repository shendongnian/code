cs
class Program
{
    static void Main()
    {
        // Print all combinations from a to b, for n dimensions
        // e.g. 0000 to 2222 <- each dimension goes from 0 to 2, with 4 dimensions
        // Note that each dimension can have a unique start/end point
        // e.g. 1234 to 5678, so the 2nd dimensions is bound 2 <= x <= 6
        int dimensions = 4;
        int[] startValues = { 0, 0, 0, 0 };
        int[] endValues = { 2, 2, 2, 2 };
        PrintCombinations(startValues, endValues, dimensions);
        Console.ReadKey();
    }
    /// <summary>
    /// Prints all combinations of numbers given inputs
    /// </summary>
    /// <param name="start">Inclusive stating integers</param>
    /// <param name="end">Inclusive ending integers</param>
    /// <param name="dimensions">The number of dimensions to iterate</param>
    private static void PrintCombinations(int[] startValues, int[] endValues, int dimensions)
    {
        // Create new array to loop through without disturbing the original array
        int[] loopArray = (int[])startValues.Clone();
        // Loop through each value
        while (!Enumerable.SequenceEqual(loopArray, endValues))
        {
            // Write array to console
            Console.WriteLine($"{string.Join(", ", loopArray)}");
            // Increment array
            loopArray[0]++;
            // Check if a dimension is larger than it's maximum, then set to min, and add +1 to next dimension
            // Do not do this for last dimension, as loop will break once the final combination is met
            for (int i = 0; i < dimensions - 1; i++)
                if (loopArray[i] > endValues[i])
                {
                    loopArray[i] = startValues[i];
                    loopArray[i + 1]++;
                }
        }
        // Write final array combination  to console
        Console.WriteLine($"{string.Join(", ", loopArray)}");
    }
}
This is a simple enough example to show how exactly I wanted to expand on the idea of "multiple dimensions" represented as an array.
If you look to the bottom of `PrintCombinations`, you will see the following code:
cs
for (int i = 0; i < dimensions - 1; i++)
    if (loopArray[i] > endValues[i])
    {
        loopArray[i] = startValues[i];
        loopArray[i + 1]++;
    }
This is the code I come up with the loop through multiple dimensions, removing the need to hard-code loops when you have user submitted dimensions and other information (as shown in the upper example).
Basically, this code stores the VALUE of each dimension in an array.
Let us do an example of 3 dimensions, (x, y, z).
We can say the point (x, y, z) = int[] { x, y, z }
If we say x, y, and z are the upper bound of the array, we can loop through this array by subtracting the array's first dimesnsion, until it reaches zero, then remove one from the following dimension until it reaches zero, etc, all while resetting the dimension to the upper bound when doing so, or as in this example, add from zero to an upper bound, then reset to zero, and increment the following dimension.
By using further arrays for upper and lower bounds, you can essentially make nested loops between two specific ranges. In the above example, I used an upper bound of `{ 2, 2, 2, 2 }`.
I hope I have explained this well. Thanks
