    public static NiceAlertController Create(string title, string message, UIImage image = null)
    {
        //New instance of your ViewController UI
        var storyboard = UIStoryboard.FromName("Main", NSBundle.MainBundle);
        var alertController = storyboard.InstantiateViewController(nameof(NiceAlertController)) as NiceAlertController;
        //Using the same transition and presentation style as the UIAlertViewController
        alertController.ModalTransitionStyle = UIModalTransitionStyle.CrossDissolve;
        alertController.ModalPresentationStyle = UIModalPresentationStyle.OverCurrentContext;
        //This assumes your properties are called Title, Message and Image 
        alertController.Title = title;
        alertController.Message = message;
        alertController.Image = image;
        return alertController;
    }
