            string s = checkboxId.Value;
            var nums = s.Split(new[]{','}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            var toBeRemoved = new List<int>{1, 2, 5};
            var newArray = nums.RemoveAll(item => toBeRemoved.Contains(item));
