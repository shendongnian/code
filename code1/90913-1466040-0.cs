    public delegate void Processor(List<int> args);
    private void CalculateCombinations(int modes, int workDays, string combinationValues, Processor processor)
    {
        if (modes == 1)
        {
            List<int> _tempList = new List<int>();
            combinationValues += Convert.ToString(workDays);
            string[] _combinations = combinationValues.Split(',');
            foreach (string _number in _combinations)
            {
                _tempList.Add(Convert.ToInt32(_number));
            }
            processor.Invoke(_tempList);
        }
        else
        {
            for (int i = workDays + 1; --i >= 0; )
            {
                CalculateCombinations(modes - 1, workDays - i, combinationValues + i + ",", processor);
            }
        }
    }
