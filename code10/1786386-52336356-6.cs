        void Handle_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            var picker = sender as Picker;
            var item = picker.BindingContext;
            var question = item as QuestionList;
            Answers.Add(question.QuestionCode, picker.SelectedItem.ToString());
        }
