    // if no one has responded,
    if (!dc.Context.Responded)
    {
        // examine results from active dialog
        switch (dialogResult.Status)
        {
            case DialogTurnStatus.Empty:
                switch (topIntent)
                {
                    case GreetingIntent:
                        await dc.BeginDialogAsync(nameof(GreetingDialog));
                        break;
                    case NoneIntent:
                        default:
                        // Help or no intent identified, either way, let's provide some help.
                        // to the user
                        await dc.Context.SendActivityAsync("I didn't understand what you just said to me.");
                        break;
                        }
                        break;
                     case DialogTurnStatus.Waiting:
                        // The active dialog is waiting for a response from the user, so do nothing.
                        break;
                    case DialogTurnStatus.Complete:
                        await dc.EndDialogAsync();
                        break;
                    default:
                        await dc.CancelAllDialogsAsync();
                        break;
                }
         }
    }
