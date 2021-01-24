    public sealed class MyData
    {
        [JsonProperty("otherdata")]
        public string OtherData {get; private set;}
        
        [JsonProperty("members")]
        private Dictionary<string, Member> _myData;
        
        private List<Member> _myMembers;
        public IReadOnlyList<Member> Members
        {
            get
            {
                if (_myMembers == null)
                {
                    _myMembers = _myData?.Values.ToList() ?? new List<Member>();
                    _myData = null; // Optional dumping of the dictionary
                }
                
                return _myMembers
            }
        }
    }
 
