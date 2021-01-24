        UIAccessibilityCustomAction someAccessibilityAction = new UIAccessibilityCustomAction(
            SwipeActionMarkTextValue("Accessibility Text", false),
            (UIAccessibilityCustomAction arg) => {
                TestAsyncMethod();
                return true;
            });
        private async void TestAsyncMethod()
        {
            await Task.Delay(5000);
        }
