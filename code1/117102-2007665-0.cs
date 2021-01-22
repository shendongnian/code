        /// <summary>
        /// Update a sentence's status to Completed [401110]
        /// </summary>
        /// <param name="senRow"></param>
        /// <param name="eventDate"></param>
        private static void CompleteSentence(DataRow senRow, DateTime eventDate)
        {
            senRow.SetField("SenStatus", "401110");
            senRow.SetField("SenStatusDate", eventDate);
        }
        /// <summary>
        /// Update a sentence's status to Terminated [401120]
        /// </summary>
        /// <param name="senRow"></param>
        /// <param name="eventDate"></param>
        private static void TerminateSentence(DataRow senRow, DateTime eventDate)
        {
            senRow.SetField("SenStatus", "401120");
            senRow.SetField("SenStatusDate", eventDate);
        }
        /// <summary>
        /// Returns true if a sentence is a DEJ sentence.
        /// </summary>
        /// <param name="senRow"></param>
        /// <returns></returns>
        private static bool DEJSentence(DataRow senRow)
        {
            return Api.ParseCode(senRow.Field<string>("SenType")) == "431320";
        }
        /// <summary>
        /// Returns true if a sentence is a Diversion sentence.
        /// </summary>
        /// <param name="senRow"></param>
        /// <returns></returns>
        private static bool DiversionSentence(DataRow senRow)
        {
            return Api.ParseCode(senRow.Field<string>("SenType")).StartsWith("43");
        }
        /// <summary>
        /// These are predicates that test a sentence row to see if it should be updated
        /// if it lives under a charge disposed with the specified disposition type.
        /// 
        /// For instance, if the PDDispositionCode is 413320, any DEJ sentence under the
        /// charge should be updated.
        /// </summary>
        private static readonly Dictionary<string, Func<DataRow, bool>> PDSentenceTests = 
            new Dictionary<string, Func<DataRow, bool>>
        {
            {"411610", DiversionSentence},  // diversion successful
            {"413320", DEJSentence},        // DEJ successful
            {"442110", DiversionSentence},  // diversion unsuccessful
            {"442111", DiversionSentence},  // diversion unsuccessful
            {"442112", DiversionSentence},  // diversion unsuccessful
            {"442120", DEJSentence}         // DEJ unsuccessful
        };
        /// <summary>
        /// These are the update actions that are applied to the sentence rows which pass the
        /// sentence test for the specified disposition type.
        /// 
        /// For instance, if the PDDispositionCode is 442110, sentences that pass the sentence
        /// test should be terminated.
        /// </summary>
        private static readonly Dictionary<string, Action<DataRow, DateTime>> PDSentenceUpdates = 
            new Dictionary<string, Action<DataRow, DateTime>>
        {
            {"411610", CompleteSentence},   // diversion successful (completed)
            {"413320", CompleteSentence},   // DEJ successful (completed)
            {"442110", TerminateSentence},  // diversion unsuccessful (terminated)
            {"442111", TerminateSentence},  // diversion unsuccessful (terminated)
            {"442112", TerminateSentence},  // diversion unsuccessful (terminated)
            {"442120", TerminateSentence}   // DEJ unsuccessful (terminated)
        };
        private void PDUpdateSentencesFromNewDisposition()
        {
            foreach (DataRow chargeRow in PDChargeRows
                .Where(x => PDSentenceTests.ContainsKey(x.Field<string>("PDDispositionCode"))))
            {
                string disp = chargeRow.Field<string>("PDDispositionCode");
                foreach (DataRow s in CHGRows[chargeRow]
                    .ChildRows("CAS-SUBCRM-CHG-SEN")
                    .Where(x => PDSentenceTests[disp](x)))
                {
                    PDSentenceUpdates[disp](s, EventDate);
                }
            }
        }
