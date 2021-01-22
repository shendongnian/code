    public void ThreadedMethod()
    {
        Gtk.Application.Invoke(delegate {
            do_stuff_in_main_thread();
        });
    }
