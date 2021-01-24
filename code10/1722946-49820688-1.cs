    private void button1_Click(object sender, EventArgs e)
    {
        // We've already asked ten questions, don't do anything else.
        if (questionsAsked > 10) return;
        // If the user entered a valid integer into the text box
        int answer;
        if (int.TryParse(txtBoxAnswer.Text, out answer))
        {
            // Implement Between if still needed.
            if (Between == 1)
            {
                if (answer == currentAnswer)
                {
                    // the answer is correct.
                }
                else
                {
                    // the answer is incorrect
                }
                int num1 = rnd.Next(1, 11); // 1-10
                int num2 = rnd.Next(1, 11); // 1-10
                currentAnswer = num1 + num2;
                kusimus.Text = String.Format("{0} + {1}", num1, num2);
            }
            // We've asked another question.
            questionsAsked++;
            if (questionsAsked > 10)
            {
                // User has answered last question, do something?
            }
        }
    }
