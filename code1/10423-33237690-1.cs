        public void WriteLine(
            [CallerFilePath] string callerFilePath = "", 
            [CallerLineNumber] long callerLineNumber = 0,
            [CallerMemberName] string callerMember= "")
        {
            Debug.WriteLine(
                "Caller File Path: {0}, Caller Line Number: {1}, Caller Member: {2}", 
                callerFilePath,
                callerLineNumber,
                callerMember);
        }
