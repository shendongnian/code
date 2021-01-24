    AppServiceResponse serviceResponse = null;
    try
    {
        // send message
        serviceResponse = await connection.SendMessageAsync(message);
    }
    catch (Exception)
    {
         // exit 
         capsLockStatusNI.Visible = false;
         numLockStatusNI.Visible = false;
         scrollLockStatusNI.Visible = false;
         Application.Exit();
     }
