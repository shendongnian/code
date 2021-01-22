    // Create the action block.  Since there's not a non-generic
    // version, make it object, and pass null to signal, or
    // make T the type that takes the input to the action
    // and pass that.
    var actionBlock = new ActionBlock<object>(o => {
        // Do work.
    });
    // Post 100 times.
    foreach (int i in Enumerable.Range(0, 100)) actionBlock.Post(null);
    // Signal complete, this doesn't actually stop
    // the block, but says that everything is done when the currently
    // posted items are completed.
    actionBlock.Complete();
    // Wait for everything to complete, the Completion property
    // exposes a Task which can be waited on.
    actionBlock.Completion.Wait();
