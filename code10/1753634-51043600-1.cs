         ThisThingClickedCommand = new Command(
        async ()=>
        {
            var continue = true;
            if (SomeVariable.is_flagged == 0)
            {
                continue = await PageSent.DisplayAlert("User Question", "This is a question for the user", "Yes", "No");
            }
        
            if (continue)
            {
                Debug.WriteLine("This debug fires");
    
    Device.BeginInvokeOnMainThread(async () =>
                var AnswerToSecondQuestion = await PageSent.DisplayAlert("Second Question", "This is a second question for the user", "Yes", "No");
                if (AnswerToSecondQuestion)
                {
                    // Do more things
                }
                Debug.WriteLine("This one does not :(");
            });
        }),
