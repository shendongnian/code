    //Rextester.Program.Main is the entry point for your code. Don't change it.
    //Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                // Set up input.
                string[,] arr = new string[,]
                {
                    { "W", "W", "W", "R", "W" },
                    { "C", "R", "R", "R", "R" },
                    { "R", "W", "W", "R", "W" },
                    { "W", "W", "W", "R", "R" },
                    { "W", "R", "R", "W", "C" }
                };
                
                // Actual algorithm for solution. 
                // Make a copy for result since recursive solution will modify array in place.
                string[,] result = arr.Clone() as string[,];
                GenerateContaminant(result);
                
                printGrid("Input:", arr);
                printGrid("Output:", result);
            }
            
            
            public static void GenerateContaminant(string[,] arr)
            {
                // Iterate through every element of the array and when you find a "C", 
                // propagate the contamination recursively to its neighbors.
                for (int row = 0; row < arr.GetLength(0); row++)
                {
                    for (int col = 0; col < arr.GetLength(1); col++)
                    {
                        if (arr[row, col] == "C") {
                            ContaminateRecurse(row, col, arr);
                        }
                    }
                }
                return;
            }        
            
            // Recurse from a "C" element and see if its neighbors should be contaminated.
            public static void ContaminateRecurse(int row, int col, string[,] arr)
            {
                arr[row, col] = "C";
                // Top Neighbor
                if (isValid(row-1, col, arr)) {
                    ContaminateRecurse(row-1, col, arr);
                }
                // Bottom Neighbor
                if (isValid(row+1, col, arr)) {
                    ContaminateRecurse(row+1, col, arr);
                }
                // Left Neighbor
                if (isValid(row, col-1, arr)) {
                    ContaminateRecurse(row, col-1, arr);
                }
                // Right Neighbor
                if (isValid(row, col+1, arr)) {
                    ContaminateRecurse(row, col+1, arr);
                }
                return;
            }
            
            // Makes sure that an element index is within the bounds of the array and is a 'W'.
            public static bool isValid(int row, int col, string[,] arr) {
                if ((0 <= row && row < arr.GetLength(0)) && 
                    (0 <= col && col < arr.GetLength(1)) && 
                    arr[row,col] == "W") {
                    return true;
                }
                else {
                    return false;
                }
            }
            
            // Write grid to console.
            public static void printGrid(string label, string[,] result) {
                Console.Write(label);
                Console.WriteLine();
                for (int rowValue = 0; rowValue < result.GetLength(0); rowValue++) {
                    for (int colValue = 0; colValue < result.GetLength(1); colValue++) {
                        Console.Write(result[rowValue, colValue]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        
        }
    }
