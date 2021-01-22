    using System;
    using System.Collections.Generic;
    namespace MathIterator
    {
      class Program
      {
        static readonly int[] _inputs = new int[] { 5, 5, 5, 5 };
        static readonly char[] _operations = new char[] { '+', '-', '*', '/' };
        static Dictionary<int, List<string>> _calculations = new Dictionary<int, List<string>>();
        
        static void Main(string[] args)
        {
          StartPermutation();
          PrintResults();
        }
        static void StartPermutation()
        {
          if (_inputs.Length > 0)
            Permute(1 /*index*/, _inputs[0], _inputs[0].ToString());    
        }
        static void Permute(int index, int result, string computation)
        {
          if (index == _inputs.Length)
          {
            if (!_calculations.ContainsKey(result))
            {
              _calculations[result] = new List<string>();
            }
            _calculations[result].Add(computation);
          }
          else
          {
            foreach (char operation in _operations)
            {
              string nextComputation = String.Format("({0} {1} {2})",computation, operation, _inputs[index]);
              int nextResult = result;
              switch (operation)
              {
                case '+':
                  nextResult += _inputs[index];
                  break;
                case '-':
                  nextResult -= _inputs[index];
                  break;
                case '*':
                  nextResult *= _inputs[index];
                  break;
                case '/':
                  nextResult /= _inputs[index];
                  break;
              }
              Permute(
                index + 1,
                nextResult,
                nextComputation);
            }
          }
        }
        static void PrintResults()
        {
          for (int i = 1; i <= 10; ++i)
          {
            if (_calculations.ContainsKey(i))
            {
              Console.WriteLine("Found {0} entries for key {1}", _calculations[i].Count, i);
              foreach (string calculation in _calculations[i])
              {
                Console.WriteLine(i + " = " + calculation);
              }
            }
            else
            {
              Console.WriteLine("No entry for key: " + i);
            }
          }
        }
      }
    }
