        /// <summary>
        /// Calculates the eta.
        /// </summary>
        /// <param name="processStarted">When the process started</param>
        /// <param name="totalElements">How many items are being processed</param>
        /// <param name="processedElements">How many items are done</param>
        /// <returns>A string representing the time left</returns>
        private string CalculateEta(DateTime processStarted, int totalElements, int processedElements)
        {
            int itemsPerSecond = processedElements / (int)(processStarted - DateTime.Now).TotalSeconds;
            int secondsRemaining = (totalElements - processedElements) / itemsPerSecond;
            return new TimeSpan(0, 0, secondsRemaining).ToString();
        }
