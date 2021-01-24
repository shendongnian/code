    _Obj = this
        .GetIsActivated()
        .Select(isActivated => isActivated ? someService.SomePipeline : Observable.Return(null))
        .Switch()
        .ToProperty(this, x => x.Obj);
