            List<int> selectedNumbers = new List<int>(){8, 5, 3, 12, 2};
            int firstNumber = selectedNumbers.OrderBy(i => i).First();
            int lastNumber = selectedNumbers.OrderBy(i => i).Last();
            
            List<int> allNumbers = Enumerable.Range(firstNumber, lastNumber - firstNumber + 1).ToList();
            List<int> missingNumbers = allNumbers.Except(selectedNumbers).ToList();
            foreach (int i in missingNumbers)
            {
                Response.Write(i);
            }
