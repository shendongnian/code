    public class SyslogMessage
    {
        private static readonly string _SyslogMsgHeaderPattern = @"\<(?<PRIVAL>\d{1,3})\>(?<VERSION>[1-9]{0,2}) (?<TIMESTAMP>(\S|\w)+) (?<HOSTNAME>-|(\S|\w){1,255}) (?<APPNAME>-|(\S|\w){1,48}) (?<PROCID>-|(\S|\w){1,128}) (?<MSGID>-|(\S|\w){1,32})";
        private static readonly string _SyslogMsgStructuredDataPattern = @"(?<STRUCTUREDDATA>-|\[[^\[\=\x22\]\x20]{1,32}( ([^\[\=\x22\]\x20]{1,32}=\x22.+\x22))?\])";
        private static readonly string _SyslogMsgMessagePattern = @"( (?<MESSAGE>.+))?";
        private static Regex _Expression = new Regex($@"^{_SyslogMsgHeaderPattern} {_SyslogMsgStructuredDataPattern}{_SyslogMsgMessagePattern}$", RegexOptions.None, new TimeSpan(0, 0, 5));
        
        public int Prival { get; private set; }
        public int Version { get; private set; }
        public DateTime TimeStamp { get; private set; }
        public string HostName { get; private set; }
        public string AppName { get; private set; }
        public string ProcId { get; private set; }
        public string MessageId { get; private set; }
        public string StructuredData { get; private set; }
        public string Message { get; private set; }
        public string RawMessage { get; private set; }
        /// <summary>
        /// Parses a Syslog message in RFC 5424 format. 
        /// </summary>
        /// <exception cref="FormatException"></exception>
        /// <exception cref="OverflowException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static SyslogMessage Parse(string rawMessage)
        {
            if (string.IsNullOrWhiteSpace(rawMessage)) { throw new ArgumentNullException("message"); }
            var match = _Expression.Match(rawMessage);
            if (match.Success)
            {
                return new SyslogMessage
                {
                    Prival = Convert.ToInt32(match.Groups["PRIVAL"].Value),
                    Version = Convert.ToInt32(match.Groups["VERSION"].Value),
                    TimeStamp = Convert.ToDateTime(match.Groups["TIMESTAMP"].Value),
                    HostName = match.Groups["HOSTNAME"].Value,
                    AppName = match.Groups["APPNAME"].Value,
                    ProcId = match.Groups["PROCID"].Value,
                    MessageId = match.Groups["MSGID"].Value,
                    StructuredData = match.Groups["STRUCTUREDDATA"].Value,
                    Message = match.Groups["MESSAGE"].Value,
                    RawMessage = rawMessage
                };
            }
            else { throw new InvalidOperationException("Invalid message."); }
        }
        public override string ToString()
        {
            var message = new StringBuilder($@"<{Prival:###}>{Version:##} {TimeStamp.ToString("yyyy-MM-ddTHH:mm:ss.fffK")} {HostName} {AppName} {ProcId} {MessageId} {StructuredData}");
            if (!string.IsNullOrWhiteSpace(Message))
            {
                message.Append($" {Message}");
            }
            return message.ToString();
        }
    }
