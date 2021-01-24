    using System;
    public class Program
    {
    	public static T[,] SplitInto2DArray<T>(T[] array, int rows, int columns) {		
    		T[,] result = new T[rows, columns];
    		
    		for (int i = 0; i < array.Length; i++) {
    			result[i / columns, i % columns] = array[i];	
    		}
    		
    		return result;
    	}
    	
    	public static void PrintArray<T>(T[,] array) {
    		for (int i = 0; i < array.GetLength(0); i++) {
    			for (int j = 0; j < array.GetLength(1); j++) {
    				Console.Write(array[i, j] + " ");
    			}
    			Console.WriteLine();
    		}
    	}
    	
    	public static void Main()
    	{
    		int[] array = { 10, 11, 12, 13, 14, 20, 21, 22, 23, 24, 30, 31, 32, 33, 34, 40, 41, 42, 43, 44};
    		int[,] splittedArray = SplitInto2DArray(array, 4, 5);
    		
    		PrintArray(splittedArray);
    	}
    }
