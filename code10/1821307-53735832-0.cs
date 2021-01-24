            public List<int> Divisors(int fact)
        {
            List<int> factors = new List<int>();
            int number = int.Parse(textBox2.Text);
            int factorCount = 0;
            int sqrt = (int)Math.Ceiling(Math.Sqrt(number));
            for (int i = 1; i < sqrt; i++)
            {
                if (number % i == 0)
                {
                    factors.Add(i);
                    factorCount += 2; //  We found a pair of factors.
                }
            }
            // Check if our number is an exact square.
            if (sqrt * sqrt == number)
            {
                factorCount++;
            }
            // return factorCount;
            return factors;
        }
        private void ShowallButton_Click(object sender, EventArgs e)
        {
            int input = int.Parse(textBox2.Text);
            List<int> factors = Divisors(input);
            string message = $"The Divisors are {string.Join(",", factors)}";
            MessageBox.Show(message);
        }
