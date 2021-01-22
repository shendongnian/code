    class PersistentDictManager {
        const int SaveAllThreshold = 1000;
        PersistentDictManager(string logpath) {
            this.LogPath = logpath;
            this.mydictionary = new Dictionary<string, string>();
            this.LoadData();
        }
        public string LogPath { get; private set; }
        public string this[string key] {
            get{ return this.mydictionary[key]; }
            set{
                string existingvalue;
                if(!this.mydictionary.TryGetValue(key, out existingvalue)) { existingvalue = null; }
                if(string.Equals(value, existingvalue)) { return; }
                this[key] = value;
                // store in log
                if(existingvalue != null) { // was an update (not a create)
                    if(this.IncrementSaveAll()) { return; } // because we're going to repeat a key the log
                }
                this.LogStore(key, value);
            }
        }
        public void Remove(string key) {
            if(!this.mydictionary.Remove(key)) { return; }
            if(this.IncrementSaveAll()) { return; } // because we're going to repeat a key in the log
            this.LogDelete(key);
        }
        private void CreateWriter() {
            if(this.writer == null) {
                this.writer = new BinaryWriter(File.Open(this.LogPath, FileMode.Open)); 
            }
        }
        private bool IncrementSaveAll() {
            ++this.saveallcount;
            if(this.saveallcount >= PersistentDictManager.SaveAllThreshold) {
                this.SaveAllData();
                return true;
            }
            else { return false; }
        }
        private void LoadData() {
            try{
                using(BinaryReader reader = new BinaryReader(File.Open(LogPath, FileMode.Open))) {
                    while(reader.PeekChar() != -1) {
                        string key = reader.ReadString();
                        bool isdeleted = reader.ReadBoolean();
                        if(isdeleted) { this.mydictionary.Remove(key); }
                        else {
                            string value = reader.ReadString();
                            this.mydictionary[key] = value;
                        }
                    }
                }
            }
            catch(FileNotFoundException) { }
        }
        private void LogDelete(string key) {
            this.CreateWriter();
            this.writer.Write(key);
            this.writer.Write(true); // yes, key was deleted
        }
        private void LogStore(string key, string value) {
            this.CreateWriter();
            this.writer.Write(key);
            this.writer.Write(false); // no, key was not deleted
            this.writer.Write(value);
        }
        private void SaveAllData() {
            if(this.writer != null) {
                this.writer.Close();
                this.writer = null;
            }
            using(BinaryWriter writer = new BinaryWriter(File.Open(this.LogPath, FileMode.Create))) {
                foreach(KeyValuePair<string, string> kv in this.mydictionary) {
                    writer.Write(kv.Key);
                    writer.Write(false); // is not deleted flag
                    writer.Write(kv.Value);
                }
            }
        }
        private readonly Dictionary<string, string> mydictionary;
        private int saveallcount = 0;
        private BinaryWriter writer = null;
    }
