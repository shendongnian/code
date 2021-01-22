    IEnumerator enumerator = this.ObjectNames.GetEnumerator();
    
    while (enumerator.MoveNext())
    {
        while (this.ResumeWhileLoop())
        {
            if (this.MoveToNextObject())
            {
                // advance the loop
                if (!enumerator.MoveNext())
                    // if false, there are no more items, so exit
                    return;
            }
            // do your stuff
        }
    }
