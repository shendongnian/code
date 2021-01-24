    async void SomethingAsync(int whatever, DynValue callback) {
        await SomeAsyncWorkBeingDone();
        if (callback.Type == DataType.Function) {
            callback.Function.Call();
        }
    }
