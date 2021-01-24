    message OuterMesage {
        oneof actionType {
            Foo foo = 1;
            Bar bar = 2;
            ...
        }
    }
    message Foo {...}
    message Bar {...}
    ...
