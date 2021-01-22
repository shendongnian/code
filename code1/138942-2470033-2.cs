    public static class RhinoExtensions
    {
        /// <summary>
        /// Clears the behavior already recorded in a Rhino Mocks stub.
        /// </summary>
        public static void ClearBehavior<T>(this T stub)
        {
            stub.BackToRecord(BackToRecordOptions.All);
            stub.Replay();
        }
    }
