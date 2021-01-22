    Context.Application.Lock();
    Context.Session.Abandon();
    Context.Application.RemoveAll();
    Context.Application.Restart();
    Context.Application.UnLock();
