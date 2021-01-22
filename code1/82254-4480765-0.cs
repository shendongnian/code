        /// <summary>
        /// Performs a pathping
        /// </summary>
        /// <param name="ipaTarget">The target</param>
        /// <param name="iHopcount">The maximum hopcount</param>
        /// <param name="iTimeout">The timeout for each ping</param>
        /// <returns>An array of PingReplys for the whole path</returns>
        public PingReply[] PerformPathping(IPAddress ipaTarget, int iHopcount, int iTimeout)
        {
            System.Collections.ArrayList arlPingReply = new System.Collections.ArrayList();
            Ping myPing = new Ping();
            PingReply prResult;
            for (int iC1 = 1; iC1 < iHopcount; iC1++)
            {
                prResult = myPing.Send(ipaTarget, iTimeout, new byte[10], new PingOptions(iC1, false));
                if (prResult.Status == IPStatus.Success)
                {
                    iC1 = iHopcount;
                }
                arlPingReply.Add(prResult);
            }
            PingReply[] prReturnValue = new PingReply[arlPingReply.Count];
            for (int iC1 = 0; iC1 < arlPingReply.Count; iC1++)
            {
                prReturnValue[iC1] = (PingReply)arlPingReply[iC1];
            }
            return prReturnValue;
        }
