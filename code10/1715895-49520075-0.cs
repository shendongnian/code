        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(nickname), nickname);
            info.AddValue(nameof(groupID), groupID);
            info.AddValue(nameof(lastSeen), lastSeen);
            info.AddValue(nameof(status), status);
        }
        public User(SerializationInfo info, StreamingContext context)
        {
            nickname = (string)info.GetValue(nameof(nickname), typeof(string));
            groupID = (string)info.GetValue(nameof(groupID), typeof(string));
            lastSeen = (DateTime)info.GetValue(nameof(lastSeen), typeof(DateTime));
            status = (Boolean)info.GetValue(nameof(status), typeof(Boolean));
        }
    }
