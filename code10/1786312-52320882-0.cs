    void Handle_Clicked(object sender, System.EventArgs e)
        {
            foreach(var getValues in survey)
            {
                getValuesOfPickers.Text = getValues.QuestionCode;
            }
        }
