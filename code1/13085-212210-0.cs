    SomeDisposableType t = new SomeDisposableType();
    try {
        OperateOnType();
    }
    finally {
       t.Dispose();
    }
    using (SomeDisposableType u = new SomeDisposableType()) {
        OperateOnType();
    }
