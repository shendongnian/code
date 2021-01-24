    public class OutlookCommunicator : IDisposable
    {
        private readonly Application _app;
        public OutlookCommunicator()
        {
            _app = new Application();
        }
        /// <summary>
        /// Username of the distribution list according to the GAL.
        /// </summary>
        private const string DistList = "redacted";
        /// <summary>
        /// Fetches a list of all usernames and names within the DistList.
        /// </summary>
        /// <returns>List&lt;string&gt; containing all usernames.</returns>
        public List<(string,string)> GetUsers()
        {
                Recipient warEngineering = _app.Session.CreateRecipient(DistList);
                List<(string,string)> usernames = warEngineering.AddressEntry.Members.Cast<AddressEntry>().Select(entry => (entry.Name,entry.Address)).ToList();
                return usernames;
            
        }
        /// <summary>
        /// Fetches all calendar events for a user falling within the provided range.
        /// </summary>
        /// <param name="from">Start search date.</param>
        /// <param name="to">End search dat.</param>
        /// <param name="username">User's calendar to search.</param>
        /// <returns></returns>
        public List<AppData> GetEventsInRange(DateTime from, DateTime to, string username)
        {
            List<AppData> appointments = new List<AppData>();
            try
            {
                Recipient teamMember = _app.Session.CreateRecipient(username);
                MAPIFolder sharedCalendar = _app.Session.GetSharedDefaultFolder(teamMember, OlDefaultFolders.olFolderCalendar);
                if (sharedCalendar.DefaultMessageClass != "IPM.Appointment" || teamMember.DisplayType != 0)
                {
                    return null; //Calendar not shared.
                }
                string sFilter = $"[End] > '{from:g}' AND [Start] < '{to:g}' AND [Recurring] = 'No'";
                Items results = sharedCalendar.Items.Restrict(sFilter);
                for (int i = results.Count; i > 0; i--)
                {
                    appointments.Add(new AppData(results[i], username));
                }
                return appointments;
            }
            catch (COMException)
            {
                return null;
            }
        }
        public void Dispose()
        {
            _app?.Quit();
        }
