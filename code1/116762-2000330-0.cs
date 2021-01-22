    public void ProcessMessages(IDictionary<string, string[]> messages) {
        foreach(string key in messages.Keys) {
            // send one message (one value in the dictionary entry) at a time
            foreach(string value in dictionary[key]) {
                // send message containing this value
            }
        }
    }
