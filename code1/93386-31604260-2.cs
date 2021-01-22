       void PrimeNumber(long number)
        {
            bool IsprimeNumber = true;
            long  value = Convert.ToInt32(Math.Sqrt(number));
            if (number % 2 == 0)
            {
                IsprimeNumber = false;
            }
            for (long i = 3; i <= value; i=i+2)
            {             
               if (number % i == 0)
                {
                   // MessageBox.Show("It is divisible by" + i);
                    IsprimeNumber = false;
                    break;
                }
               
            }
            if (IsprimeNumber)
            {
                MessageBox.Show("Yes Prime Number");
            }
            else
            {
                MessageBox.Show("No It is not a Prime NUmber");
            }
        }
