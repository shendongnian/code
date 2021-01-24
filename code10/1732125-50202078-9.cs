    async void Click(sender s, …) {
        var D = new ContentDialog1();
        ContentDialogResult Result = await D.ShowAsync();
        switch(Result) {
            // Ok Button
            case ContentDialogResult.Primary:
                // this might require a little bit of fixing
                // to save result in public variable...
                // because A1ListBox is not public visible...
                // but the idea is similar...
                var SelectedItem = D.A1ListBox.SelectedItem;
                DoSomethingOk();
                break;
            // Cancel Button
            case ContentDialogResult.Seconday:
                DoSomethingCancel();
                break;
        }
    }
