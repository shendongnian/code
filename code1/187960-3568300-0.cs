    Subject<int> _Progress;
    IObservable<int> Progress {
        get { return _Progress; }
    }
    private void setProgress(int new_value) {
        _Progress.OnNext(new_value);
    }
    private void wereDoneWithWorking() {
        _Progress.OnCompleted();
    }
    private void somethingBadHappened(Exception ex) {
        _Progress.OnError(ex);
    }
