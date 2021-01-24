        if (counter > 0)//you don't need the same check 2x
        {
            mean = sum / counter;
            for (int i = 0; i < listBox2.Items.Count; i++)
                sumSquares += (Convert.ToDouble(listBox2.Items[i]) * Convert.ToDouble(listBox2.Items[i]));
            squareSums += sum * sum;
            //sumSquares += Math.Pow((sum - mean), 2);//You changed the formula again here
            double numerator = counter * sumSquares - squareSums;
            double denominator = counter * (counter - 1);
            stdDev = Math.Sqrt(numerator / denominator);
            textBox2.Text = mean.ToString();
            //textBox3.Text = numerator.ToString();//You changed how you did things again
            textBox3.Text = stdDev.ToString("F");
        }
