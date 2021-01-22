    public static void appendData(string data)
        {
            if (isRecording) 
                {
                    sb.Append(data);
                    sb.Append(Environment.NewLine);
                }
        }
