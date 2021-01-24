    private void ShowallButton_Click(object sender, EventArgs e)
        {
            var input = int.Parse(textBox2.Text);
            var output = Divisors(input);
            var message = string.Join(Environment.NewLine, output);
            MessageBox.Show(message);
        }
        public List<int> Divisors(int number)
        {
            var factors = new List<int>();
            for (var i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    factors.Add(i);
                }
            }
            return factors;
        }
