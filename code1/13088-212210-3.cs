    SomeDisposableType t = new SomeDisposableType();
    try {
        OperateOnType(t);
    }
    finally {
        if (t != null) {
            ((IDisposable)t).Dispose();
        }
    }
<!--> 
    using (SomeDisposableType u = new SomeDisposableType()) {
        OperateOnType(u);
    }
