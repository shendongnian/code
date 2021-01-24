    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    
    namespace Example
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<List<dynamic>> data = new List<List<dynamic>>();
    
                data.Add(new List<dynamic>());
                data[0].AddRange(Enumerable.Range(0, 1000).Cast<dynamic>()); // Add a list of ints
                data.Add(new List<dynamic>());
                data[1].AddRange(Enumerable.Range(0, 1000).Select(v=>(float)v).Cast<dynamic>()); // Add a list of ints
                data.Add(new List<dynamic>());
                data[2].AddRange(Enumerable.Range(0, 1000).Select(v => (double)v).Cast<dynamic>()); // Add a list of ints
    
                data.Add(GenerateColoumn(data[0], data[0], Operation.Add)); // Result should be int coloumn
                data.Add(GenerateColoumn(data[0], data[1], Operation.Subtract)); // Result should be float coloumn
                data.Add(GenerateColoumn(data[1], data[2], Operation.Divide)); // Result should be double coloumn
    
                foreach (List<dynamic> lst in data)
                {
                    Debug.WriteLine((Type)lst[0].GetType());
                }
            }
    
            // This is what I would do if the lists were all the same type
            static List<dynamic> GenerateColoumn(List<dynamic> colA, List<dynamic> colB,Operation operation)
            {
                List<dynamic> result = null;
    
                switch (operation)
                {
                    case Operation.Add:
                        result = colA.Zip(colB, (a, b) => a + b).ToList();
                        break;
                    case Operation.Subtract:
                        result = colA.Zip(colB, (a, b) => a - b).ToList();
                        break;
                    case Operation.Multiply:
                        result = colA.Zip(colB, (a, b) => a * b).ToList();
                        break;
                    case Operation.Divide:
                        result = colA.Zip(colB, (a, b) => a / b).ToList();
                        break;
                }
                return result;
            }
    
            public enum Operation
            {
                Add,
                Subtract,
                Multiply,
                Divide
            }
        }
    }
