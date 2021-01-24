        private async Task<bool> CheckWithTimeout(Predicate toBeChecked, int msToWait)
        {
            var waitTask = Task.Delay(msToWait);
            var checkTask = Task.Run(toBeChecked);
            await Task.WhenAny(waitTask, checkTask);
            return checkTask.IsCompleted && await checkTask;
        }
