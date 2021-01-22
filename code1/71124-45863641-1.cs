            public static void CallIfNonEmpty(string value, Action<string> action)
        {
            if (!string.IsNullOrEmpty(value))
                action(value);
        }
