    void SomeMethod()
    {
       var dialog = new YesNoCancelDialog();
       dialog.Closed += (s, args) =>
       {
         switch (dialog.Result)
         {
            //Handle resulting user choice
         }
       }
       dialog.Show();
    }
