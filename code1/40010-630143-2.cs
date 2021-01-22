    internal static class MockExtension {
        public static void ClearBehavior<T>(this T fi)
        {
            // Switch back to record and then to replay - that 
            // clears all behaviour and we can program new behavior.
            // Record/Replay do not occur otherwise in our tests, that another method of
            // using Rhino Mocks.
            fi.BackToRecord(BackToRecordOptions.All);
            fi.Replay();
        }
    }
