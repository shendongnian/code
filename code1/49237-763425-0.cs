    class CustomClass {
        public void SaveDataAsync(string path) {
            ThreadPool.QueueUserWorkItem(state => this.SaveData(path));
        }
        public void SaveData(string path) {
            ...
        }
    }
