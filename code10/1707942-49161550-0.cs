    public class GroupUserid {
        public int group;
        public int userid;
    }
    var rawdata = List<GroupUserid>();
    var groupMembership = rawdata.ToLookup(d => d.group, d => d.userid);
