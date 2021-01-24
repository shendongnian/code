    Observable.Create((observer, outerCancel) =>
        Observable.FromAsync(innerCancel =>
                speechService.StartListeningAsync(
                    observer.OnNext,
                    innerCancel,
                    observer.OnError,
                    interimResults
                ))
            .Subscribe(observer, outerCancel)
    );
