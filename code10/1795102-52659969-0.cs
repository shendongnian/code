    private static Random rand = new Random();
    private void checkButton_Click(object sender, EventArgs e)
    {
        int num1 = rand.Next(400) + 100;
        int num2 = rand.Next(400) + 100;
        label1.Text = num1.ToString();
        label2.Text = num2.ToString();
        int correctAnswer = num1 + num2;
        int userAnswer = Convert.ToInt32(textBox1.Text);
            if (userAnswer == correctAnswer)
            {
                MessageBox.Show("Your Answer is Correct");
            }
            else
            {
                MessageBox.Show("Your Answer is Incorrect");
            }
    }
