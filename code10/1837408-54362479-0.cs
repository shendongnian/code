     public void SuperStepProgressMethod(Dictionary<string, string> stepDictionary)
            {
                DispatcherHelper.CheckBeginInvokeOnUI(
                    () =>
                    {
                        // Set step item list
                        StepItems = StepProgressHandler.UpdateStepList(stepDictionary);
                    });
            }
