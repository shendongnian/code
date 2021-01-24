    var newPage = new ContentPage ();
    await Navigation.PushAsync (newPage);
    Debug.WriteLine ("the new page is now showing");
    var poppedPage = await Navigation.PopAsync ();
    Debug.WriteLine ("the new page is dismissed");
    Debug.WriteLine (Object.ReferenceEquals (newPage, poppedPage)); //prints "true"
