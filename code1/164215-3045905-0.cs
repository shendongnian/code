            const double MIN_VALUE = 0.01;
            var values = new List<double>();
            var rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                values.Add(rand.Next(0, 100) / 10);
            }
            double sum = 0, min = 0, max = 0;
            for (int i = 0; i < values.Count; i++)
            {
                var value = values[i];
                sum += value;
                min = Math.Min(value, min);
                max = Math.Max(value, max);
            }
            if (min == 0) min = MIN_VALUE;
            if (max == 0) max = MIN_VALUE;
            while (Math.Abs(sum - 100) > MIN_VALUE)
            {
                if (sum > 100)
                    sum -= max;
                if (sum < 100)
                    sum += min;
            }
