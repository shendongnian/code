    // In order to clone your variable, you may need to inherit from 
    // ICloneable and implement the Clone function.
    bool MyFunction(ICloneable c)
    {
        // 1. Create a copy of your variable
        ICloneable clone = c.Clone();
        
        // 2. Do whatever you want in here
        ...
        
        // 3. Now check your condition
        if (condition)
        {
            // Copy all the attributes back across to c from your clone
            // (You'll have to write the ResetAttributes method yourself)
            c.ResetAttributes(clone);
            // Put a message box up
            MessageBox.Show("This failed!");
            // Now let the caller know that the function failed
            return false;
        }
        else
        {
            // Let the caller know that the function succeeded
            return true;
        }
    }
