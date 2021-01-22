    using System;
    using System.Collections.Generic;
    namespace AddUpClient {
        class Program {
            static void Main() {
                AddUpWorker worker = new AddUpWorker();
                int MinDigit = 1;
                int MaxDigit = 9;
                int ItemsToSum = 30;
                int TargetSum = 150;
                try {
                    //Attempt to get a list of pseudo-random list of integers that add up to the target sum
                    IList<int> Results = worker.AddUp(MinDigit, MaxDigit, ItemsToSum, TargetSum);
                    EvaluateResults(TargetSum, Results);
                    Console.ReadLine();
                }
                catch (Exception E) {
                    Console.Out.WriteLine("Error: {0}", E.Message);
                    return;
                }
            }
            private static void EvaluateResults(int TargetSum, IList<int> Results)
            {
                Console.Out.WriteLine("Results have {0} items.", Results.Count);
                int Sum = 0;
                foreach (int Result in Results) {
                    Sum += Result;
                    Console.Out.WriteLine("Result: {0} Running total: {1}", Result, Sum);
                }
                Console.Out.WriteLine();
                Console.Out.WriteLine("Result = {0}", (Sum == TargetSum ? "SUCCESS" : "FAIL"));
            }
        }
        internal class AddUpWorker {
            Random RGenerator = new Random();
            public IList<int> AddUp(int MinDigit, int MaxDigit, int ItemsToSum, int TargetSum) {
                Console.Out.WriteLine("AddUp called to sum {0} items to get {1}", ItemsToSum, TargetSum);
                if (ItemsToSum > 3) {
                    int LeftItemsToSum = ItemsToSum/2;
                    int RightItemsToSum = ItemsToSum - LeftItemsToSum;
                    int LeftTargetSum = TargetSum/2;
                    int RightTargetSum = TargetSum - LeftTargetSum;
                    IList<int> LeftList = AddUp(MinDigit, MaxDigit, LeftItemsToSum, LeftTargetSum);
                    IList<int> RightList = AddUp(MinDigit, MaxDigit, RightItemsToSum, RightTargetSum);
                    List<int> Results = new List<int>();
                    Results.AddRange(LeftList);
                    Results.AddRange(RightList);
                    return Results;
                }
                // 3 or less
                int MinSumWeCanAchieve = ItemsToSum*MinDigit;
                int MaxSumWeCanAchieve = ItemsToSum*MaxDigit;
                if (TargetSum < MinSumWeCanAchieve)
                    throw new ApplicationException("We added up too fast");
                if (TargetSum > MaxSumWeCanAchieve)
                    throw new ApplicationException("We added up too slow");
                //Now we know we can achieve the result -- but it may not be too efficient...
                int[] TrialNumbers = new int[ItemsToSum];
                int MaxIteration = 100000;
                int IterationPrintInterval = 1000;
                int TrialSum;
                bool PrintIteration;
                for (int Iteration = 1; Iteration <= MaxIteration; ++Iteration) {
                    PrintIteration = ((Iteration % IterationPrintInterval) == 0);
                    if (PrintIteration)
                        Console.Out.WriteLine("Iteration {0} attempting to sum {1} numbers to {2}",
                            Iteration, ItemsToSum, TargetSum);
                    TrialSum = 0;
                    for (int j=0; j < ItemsToSum; ++j) {
                        TrialNumbers[j] = RGenerator.Next(MinDigit, MaxDigit + 1);
                        TrialSum += TrialNumbers[j];
                    }
                    if (PrintIteration)
                        ShowArray(string.Format("Iteration: {0}", Iteration), TrialNumbers);
                    if (TrialSum == TargetSum) {    //Yay
                        ShowArray(string.Format("Success in {0} iterations: ", Iteration), TrialNumbers);
                        return new List<int>(TrialNumbers);
                    }
                    //try again....
                }
                throw new ApplicationException(string.Format("Maximum of {0} trials exceeded", MaxIteration));
            }
            private void ShowArray(string Prefix, int[] numbers)
            {
                for (int i = 0; i < numbers.Length; ++i) {
                    if (i == 0)
                        Console.Write("{0} {1}", Prefix, numbers[i]);
                    else
                        Console.Write(", {0}", numbers[i]);
                }
                Console.WriteLine();
            }
        }
    }
	AddUp called to sum 30 items to get 150
	AddUp called to sum 15 items to get 75
	AddUp called to sum 7 items to get 37
	AddUp called to sum 3 items to get 18
	Success in 10 iterations:  7, 2, 9
	AddUp called to sum 4 items to get 19
	AddUp called to sum 2 items to get 9
	Success in 12 iterations:  5, 4
	AddUp called to sum 2 items to get 10
	Success in 2 iterations:  1, 9
	AddUp called to sum 8 items to get 38
	AddUp called to sum 4 items to get 19
	AddUp called to sum 2 items to get 9
	Success in 11 iterations:  4, 5
	AddUp called to sum 2 items to get 10
	Success in 6 iterations:  8, 2
	AddUp called to sum 4 items to get 19
	AddUp called to sum 2 items to get 9
	Success in 3 iterations:  8, 1
	AddUp called to sum 2 items to get 10
	Success in 1 iterations:  4, 6
	AddUp called to sum 15 items to get 75
	AddUp called to sum 7 items to get 37
	AddUp called to sum 3 items to get 18
	Success in 3 iterations:  4, 6, 8
	AddUp called to sum 4 items to get 19
	AddUp called to sum 2 items to get 9
	Success in 17 iterations:  3, 6
	AddUp called to sum 2 items to get 10
	Success in 24 iterations:  1, 9
	AddUp called to sum 8 items to get 38
	AddUp called to sum 4 items to get 19
	AddUp called to sum 2 items to get 9
	Success in 3 iterations:  2, 7
	AddUp called to sum 2 items to get 10
	Success in 3 iterations:  1, 9
	AddUp called to sum 4 items to get 19
	AddUp called to sum 2 items to get 9
	Success in 4 iterations:  5, 4
	AddUp called to sum 2 items to get 10
	Success in 2 iterations:  9, 1
	Results have 30 items.
	Result: 7 Running total: 7
	Result: 2 Running total: 9
	Result: 9 Running total: 18
	Result: 5 Running total: 23
	Result: 4 Running total: 27
	Result: 1 Running total: 28
	Result: 9 Running total: 37
	Result: 4 Running total: 41
	Result: 5 Running total: 46
	Result: 8 Running total: 54
	Result: 2 Running total: 56
	Result: 8 Running total: 64
	Result: 1 Running total: 65
	Result: 4 Running total: 69
	Result: 6 Running total: 75
	Result: 4 Running total: 79
	Result: 6 Running total: 85
	Result: 8 Running total: 93
	Result: 3 Running total: 96
	Result: 6 Running total: 102
	Result: 1 Running total: 103
	Result: 9 Running total: 112
	Result: 2 Running total: 114
	Result: 7 Running total: 121
	Result: 1 Running total: 122
	Result: 9 Running total: 131
	Result: 5 Running total: 136
	Result: 4 Running total: 140
	Result: 9 Running total: 149
	Result: 1 Running total: 150
	Result = SUCCESS
	
