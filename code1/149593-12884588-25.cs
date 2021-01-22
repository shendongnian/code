    // The buffer block.
    var buffer = new BufferBlock<int>();
    // Create the action block.  Since there's not a non-generic
    // version, make it object, and pass null to signal, or
    // make T the type that takes the input to the action
    // and pass that.
    var actionBlock = new ActionBlock<int>(o => {
        // Do work.
    });
    // Link the action block to the buffer block.
    // NOTE: An IDisposable is returned here, you might want to dispose
    // of it, although not totally necessary if everything works, but
    // still, good housekeeping.
    using (link = buffer.LinkTo(actionBlock, 
        // Want to propagate completion state to the action block.
        new DataflowLinkOptions {
            PropagateCompletion = true,
        },
        // Can filter on items flowing through if you want.
        i => true)
    { 
        // Post 100 times to the *buffer*
        foreach (int i in Enumerable.Range(0, 100)) buffer.Post(i);
        // Signal complete, this doesn't actually stop
        // the block, but says that everything is done when the currently
        // posted items are completed.
        actionBlock.Complete();
        // Wait for everything to complete, the Completion property
        // exposes a Task which can be waited on.
        actionBlock.Completion.Wait();
    }
