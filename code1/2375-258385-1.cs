    private void mCoolObject_CoolEvent(object sender, CoolObjectEventArgs args)
    {
        // You could use "() =>" in place of "delegate"; it's a style choice.
        this.Invoke(delegate
        {
            // Do the dirty work of my method here.
        });
    }
