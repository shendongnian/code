    internal class StringSaver
    {
        public void Save()
        {
            if(BeforeSave != null)
            {
                var shouldProceed = BeforeSave(thingsToSave);
                if(!shouldProceed) return;
            }
            BeforeSave(thingsToSave);
            // do the save
            if (AfterSave != null) AfterSave();
        }
        IList<string> thingsToSave;
        public void Add(string thing) { thingsToSave.Add(thing); }
        public Verification BeforeSave;
        public Notification AfterSave;
    }
    public delegate bool Verification(IEnumerable<string> thingsBeingSaved);
    public delegate void Notification();
    public class SomeUtility
    {
        public void SaveSomeStrings(params string[] strings)
        {
            var saver = new StringSaver
                {
                    BeforeSave = ValidateStrings, 
                    AfterSave = ReportSuccess
                };
            foreach (var s in strings) saver.Add(s);
            saver.Save();
        }
        bool ValidateStrings(IEnumerable<string> strings)
        {
            return !strings.Any(s => s.Contains("RESTRICTED"));
        }
        void ReportSuccess()
        {
            Console.WriteLine("Saved successfully");
        }
    }
