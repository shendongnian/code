        Delegate[] invocationList = TextChanged.GetInvocationList().Clone();
        foreach (EventHandler h in invocationList) {
            try {
                TextChanged -= h
            } catch (Exception exception) {
                Console.WriteLine(exception.Message);
            }
        }
        foreach (EventHandler h in invocationList) {
            try {
                TextChanged += h
            } catch (Exception exception) {
                Console.WriteLine(exception.Message);
            }
        }
