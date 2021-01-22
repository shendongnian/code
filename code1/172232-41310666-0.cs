            int[] answer = { 1, 3, 4, 6, 8, 9, 5, 4, 0, 6 };
            int[] exam = { 1, 2, 3, 6, 8, 9, 5, 4, 0, 7 };
            int correctAnswers = 0;
            int wrongAnswers = 0;
            for (int index = 0; index < answer.Length; index++)
            {
                if (answer[index] == exam[index])
                {
                    correctAnswers += 1;
                }
                else
                {
                    wrongAnswers += 1;
                }
            }
            outputLabel.Text = ("The matching numbers are " + correctAnswers +
                "\n" + "The non matching numbers are " + wrongAnswers);
        }
