    /// <summary>
    /// Generate a tiny form that prompts the user for the language to use.
    /// </summary>
    private void prompt_for_language()
    {            
        QuestionForm.Text = "Language";
        Label lbLanguageChoice = new Label();
        lbLanguageChoice.Text = "Choose a Language";
        lbLanguageChoice.Location = new Point(1, 1);
        lbLanguageChoice.Size = new Size(200, lbLanguageChoice.Size.Height);
            
        ComboBox LanguageChoices = new ComboBox();
        LanguageChoices.Location = new Point(1, lbLanguageChoice.Location.Y + lbLanguageChoice.Height + 5);
        List<string> language_list = LanguageList();
        language_list.Sort();
        for (int loop = 0; loop < language_list.Count; loop++)
            LanguageChoices.Items.Add(language_list[loop]);
        int def = language_list.IndexOf(CurrentLanguage);
        if (def < 0) def = language_list.IndexOf(DefaultLanguage);
        if (def < 0) def = 0;
        if (language_list.Count < 1) return; //we cannot prompt when there are no languages defined
        if (def >= 0) LanguageChoices.SelectedIndex = def;
        Button Done = new Button();
        Done.Click += btnClose_Click;
        Done.Text = "Done";
        Done.Location = new Point(1, LanguageChoices.Location.Y + LanguageChoices.Height + 5); ;
        QuestionForm.Controls.Add(LanguageChoices);
        QuestionForm.Controls.Add(Done);
        QuestionForm.Controls.Add(lbLanguageChoice);
        QuestionForm.FormBorderStyle = FormBorderStyle.FixedDialog;
        QuestionForm.AutoSize = true;
        QuestionForm.Height = Done.Location.Y + Done.Height + 5; //This is too small for the form, it autosizes to "big enough"
        QuestionForm.Width = LanguageChoices.Location.X + LanguageChoices.Width + 5;
        QuestionForm.ShowDialog();
        if (LanguageChoices.SelectedIndex >= 0)
        {
            SetLanguage(LanguageChoices.SelectedItem.ToString());
        }
    }
    /// <summary>
    /// Used by prompt_for_language -> done button. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnClose_Click(object sender, EventArgs e)
    {
        if(QuestionForm != null)
            QuestionForm.Close();
    }
