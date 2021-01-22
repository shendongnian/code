        /// <summary>
        /// When deleting the Category, need to preserve the existing counter values
        /// </summary>
        private static Dictionary<string, long> GetPreservedValues(string category, XmlNodeList nodes)
        {
            Dictionary<string, long> preservedValues = new Dictionary<string, long>();
            foreach (XmlNode counterNode in nodes)
            {
                string counterName = counterNode.Attributes["name"].Value;
                if (PerformanceCounterCategory.CounterExists(counterName, category))
                {
                    PerformanceCounter performanceCounter = new PerformanceCounter(category, counterName, false);
                    preservedValues.Add(counterName, performanceCounter.RawValue);
                    Console.WriteLine(string.Format("Preserving {0} with a RawValue of {1}", counterName, performanceCounter.RawValue));
                }
                else
                {
                    Console.WriteLine(string.Format("Unable to preserve {0} becaue it doesn't exist", counterName));
                }
            }
            return preservedValues;
        }
        /// <summary>
        /// Restore preserved values after the category has been re-created
        /// </summary>
        private static void SetPreservedValues(string category, Dictionary<string, long> preservedValues)
        {
            foreach (KeyValuePair<string, long> preservedValue in preservedValues)
            {
                PerformanceCounter performanceCounter = new PerformanceCounter(category, preservedValue.Key, false);
                performanceCounter.RawValue = preservedValue.Value;
                Console.WriteLine(string.Format("Restoring {0} with a RawValue of {1}", preservedValue.Key, performanceCounter.RawValue));
            }
        }
