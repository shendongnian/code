        private async Task<bool> CheckWithTimeout(Func<bool> toBeChecked, int msToWait)
        {
            var waitTask = Task.Delay(msToWait);
            var checkTask = Task.Run(toBeChecked);
            await Task.WhenAny(waitTask, checkTask);
            return checkTask.IsCompleted && await checkTask;
        }
        private async Task<bool> CheckWithTimeout<T>(Predicate<T> toBeChecked, T predicateParameter, int msToWait)
        {
            var waitTask = Task.Delay(msToWait);            
            var checkTask = Task.Run(() => toBeChecked(predicateParameter));
            await Task.WhenAny(waitTask, checkTask);
            return checkTask.IsCompleted && await checkTask;
        }
