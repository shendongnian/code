    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    
    namespace MathIterator
    {
      class Program
      {
        static readonly int[] _inputs = new[] { 5, 5, 5, 5 };
        //HUGE hack, the '–' is a wide dash NOT a hyphen.
        static readonly char[][] _operationLevels = new[] { new[] { '*', '/' }, new[] { '+', '–' } };
        static List<string> _calculations = new List<string>();
        static Dictionary<int, List<string>> _results = new Dictionary<int, List<string>>();
        
        static void Main(string[] args)
        {
          StartPermutation();
          StartEvaluateCalculations();
          PrintResults();
        }
    
        static void StartPermutation()
        {
          if (_inputs.Length > 0)
            Permute(1 /*index*/, _inputs[0].ToString());    
        }
    
        static void Permute(int index, string computation)
        {
          if (index == _inputs.Length)
          {
            _calculations.Add(computation);
          }
          else
          {
            foreach (char[] operationLevel in _operationLevels)
            {
              foreach (char operation in operationLevel)
              {
                string nextComputation = String.Format("{0} {1} {2}", computation, operation, _inputs[index]);
                Permute(
                  index + 1,
                  nextComputation);
              }
            }
          }
        }
    
        static void StartEvaluateCalculations()
        {
          foreach (string calculation in _calculations)
          {
            int? result = EvaluateCalculation(calculation);
    
            if (result != null)
            {
              int intResult = (int) result;
    
              if (!_results.ContainsKey(intResult))
              {
                _results[intResult] = new List<string>();
              }
    
              _results[intResult].Add(calculation);            
            }
          }
        }
    
        static int? EvaluateCalculation(string calculation)
        {
          foreach (char[] operationLevel in _operationLevels)
          {
            string[] results = calculation.Split(operationLevel, 2);
    
            if (results.Length == 2)
            {
              int hitIndex = results[0].Length;
    
              Regex firstDigit = new Regex(@"^ -?\d+");
              Regex lastDigit = new Regex(@"-?\d+ $");
    
              string firstMatch = lastDigit.Match(results[0]).Value;
              int arg1 = int.Parse(firstMatch);
    
              string lastMatch = firstDigit.Match(results[1]).Value; 
              int arg2 = int.Parse(lastMatch);
    
              int result = 0;
    
              switch (calculation[hitIndex])
              {
                case '+':
                  result = arg1 + arg2;
                  break;
                //HUGE hack, the '–' is a wide dash NOT a hyphen.
                case '–':
                  result = arg1 - arg2;
                  break;
                case '*':
                  result = arg1 * arg2;
                  break;
                case '/':
                  if ((arg2 != 0) && ((arg1 % arg2) == 0))
                  {
                    result = arg1 / arg2;
                    break;
                  }
                  else
                  {
                    return null;
                  }
              }
    
              string prePiece = calculation.Remove(hitIndex - 1 - arg1.ToString().Length);
              string postPiece = calculation.Substring(hitIndex + 1 + lastMatch.ToLower().Length);
    
              string nextCalculation = prePiece + result + postPiece;
              return EvaluateCalculation(nextCalculation);
            }
          }
    
          return int.Parse(calculation);
        }
    
        static void PrintResults()
        {
          for (int i = 1; i <= 10; ++i)
          {
            if (_results.ContainsKey(i))
            {
              Console.WriteLine("Found {0} entries for key {1}", _results[i].Count, i);
    
              foreach (string calculation in _results[i])
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
