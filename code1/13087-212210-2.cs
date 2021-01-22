    SomeDisposableType t = new SomeDisposableType();
    try {
        OperateOnType(t);
    }
    finally {
       t.Dispose();
    }
<!--> 
    using (SomeDisposableType u = new SomeDisposableType()) {
        OperateOnType(u);
    }
