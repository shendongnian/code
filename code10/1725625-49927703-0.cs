    private void ListBoxQuestionAnswers_OnSelectionChanged (object sender, SelectionChangedEventArgs e)
    {
        if (ListBoxQuestionAnswers.SelectedIndex == Question.CorrectAnswerIndex)
        {
            ListBoxQuestionAnswers.Resources ["SystemControlHighlightListAccentLowBrush"] = new SolidColorBrush (Colors.Green);
            ListBoxQuestionAnswers.Resources ["SystemControlHighlightListAccentMediumBrush"] = new SolidColorBrush (Colors.Green);
        }
        else
        {
            ListBoxQuestionAnswers.Resources ["SystemControlHighlightListAccentLowBrush"] = new SolidColorBrush (Colors.Red);
            ListBoxQuestionAnswers.Resources ["SystemControlHighlightListAccentMediumBrush"] = new SolidColorBrush (Colors.Red);
        }
    
    }
