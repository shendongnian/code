    // Do some stuff, an exception thrown here won't be caught.
    try
    {
      // Do stuff
      throw new InvalidOperationException("Some state was invalid.");
      // Nothing here will be executed because the exception has been thrown
    }
    catch(InvalidOperationException ex) // Catch and handle the exception
    {
      // This code is responsible for dealing with the error condition
      //   that prompted the exception to be thrown.  We choose to name
      //   the exception "ex" in this block.
    }
    // This code will continue to execute as usual because the exception
    //   has been handled.
