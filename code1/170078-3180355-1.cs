    static class SessionManager { // non-generic!
        static void Connect<T>(T item) where T : DuplexServiceBase {
            SessionManager<T>.Current.Connect(item);
        }
    }
