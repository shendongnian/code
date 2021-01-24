    if (context.Activity.Type == ActivityTypes.Message)
    {
        var uparam = context.Activity.From.Properties["userparam"].ToString();
        // Your code logic here   
        
    
        // Echo back to the user whatever they typed.
        await context.SendActivity($"Turn {state.TurnCount}: You sent '{context.Activity.Text}; Parameter you passed is {uparam}'");
    }
