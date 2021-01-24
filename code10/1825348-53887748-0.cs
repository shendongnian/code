        public class DriveClass
        {
            public int Drive { get; set; }
            public string Volume { get; set; }
            public override string ToString()
            {
                return String.Format("{{Drive = {0} Volume = {1}}}", Drive, Volume);
            }
        }
