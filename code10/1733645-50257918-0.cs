        public class Member
        {
           public string email_Address { get; set; }
           public string status { get; set; }
           public MergeFields merge_fields { get; set; }
           
           public Member(){
              merge_fields = new MergeFields();
           }
        }
