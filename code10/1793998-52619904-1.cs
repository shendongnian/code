    var jsonMessage = "{ \"meta\": {  \"warnings\": [],  \"page\": {   \"current\": 1,   \"total_pages\": 1,   \"total_results\": 2,   \"size\": 10  },  \"request_id\": \"6887a53f701a59574a0f3a7012e01aa8\" }, \"results\": [{   \"phone\": {    \"raw\": 3148304280.0   },   \"accounts_balance_ach\": {    \"raw\": 27068128.71   },   \"accounts_balance_pending\": {    \"raw\": \"46809195.64\"   },   \"email\": {    \"raw\": \"Brisa34@hotmail.com\"   },   \"accounts_count\": {    \"raw\": 6.0   },   \"id\": {    \"raw\": \"c98808a2-d7d6-4444-834d-2fe4f6858f6b\"   },   \"display_name\": {    \"raw\": \"The Johnstons\"   },   \"type\": {    \"raw\": \"Couple\"   },   \"advisor_email\": {    \"raw\": \"Cornelius_Schiller14@hotmail.com\"   },   \"created_at\": {    \"raw\": \"2018-10-02T10:42:07+00:00\"   },   \"source\": {    \"raw\": \"event\"   },   \"accounts_balance\": {    \"raw\": 43629003.47   },   \"accounts_donations\": {    \"raw\": 38012278.75   },   \"advisor_name\": {    \"raw\": \"Cloyd Jakubowski\"   },   \"_meta\": {    \"score\": 0.42934617   }  },  {   \"phone\": {    \"raw\": 2272918612.0   },   \"accounts_balance_ach\": {    \"raw\": 35721452.35   },   \"accounts_balance_pending\": {    \"raw\": \"35117465.2\"   },   \"email\": {    \"raw\": \"Ruby87@yahoo.com\"   },   \"accounts_count\": {    \"raw\": 1.0   },   \"id\": {    \"raw\": \"687af11f-0f73-4112-879c-1108303cb07a\"   },   \"display_name\": {    \"raw\": \"Kennith Johnston\"   },   \"type\": {    \"raw\": \"Individual\"   },   \"advisor_email\": {    \"raw\": \"Evangeline_Wisoky92@hotmail.com\"   },   \"created_at\": {    \"raw\": \"2018-10-02T16:16:02+00:00\"   },   \"source\": {    \"raw\": \"website\"   },   \"accounts_balance\": {    \"raw\": 23063874.19   },   \"accounts_donations\": {    \"raw\": 33025175.79   },   \"advisor_name\": {    \"raw\": \"Ernie Mertz\"   },   \"_meta\": {    \"score\": 0.39096162   }  } ]}";
    
    var message = JsonConvert.DeserializeObject<RootObject>(jsonMessage);
    Console.WriteLine(message.meta.page.current); // prints 1
    public class Page
    {
        public int current { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
        public int size { get; set; }
    }
    
    public class Meta
    {
        public List<object> warnings { get; set; }
        public Page page { get; set; }
        public string request_id { get; set; }
    }
    
    public class Phone
    {
        public double raw { get; set; }
    }
    
    public class AccountsBalanceAch
    {
        public double raw { get; set; }
    }
    
    public class AccountsBalancePending
    {
        public string raw { get; set; }
    }
    
    public class Email
    {
        public string raw { get; set; }
    }
    
    public class AccountsCount
    {
        public double raw { get; set; }
    }
    
    public class Id
    {
        public string raw { get; set; }
    }
    
    public class DisplayName
    {
        public string raw { get; set; }
    }
    
    public class Type
    {
        public string raw { get; set; }
    }
    
    public class AdvisorEmail
    {
        public string raw { get; set; }
    }
    
    public class CreatedAt
    {
        public DateTime raw { get; set; }
    }
    
    public class Source
    {
        public string raw { get; set; }
    }
    
    public class AccountsBalance
    {
        public double raw { get; set; }
    }
    
    public class AccountsDonations
    {
        public double raw { get; set; }
    }
    
    public class AdvisorName
    {
        public string raw { get; set; }
    }
    
    public class Meta2
    {
        public double score { get; set; }
    }
    
    public class Result
    {
        public Phone phone { get; set; }
        public AccountsBalanceAch accounts_balance_ach { get; set; }
        public AccountsBalancePending accounts_balance_pending { get; set; }
        public Email email { get; set; }
        public AccountsCount accounts_count { get; set; }
        public Id id { get; set; }
        public DisplayName display_name { get; set; }
        public Type type { get; set; }
        public AdvisorEmail advisor_email { get; set; }
        public CreatedAt created_at { get; set; }
        public Source source { get; set; }
        public AccountsBalance accounts_balance { get; set; }
        public AccountsDonations accounts_donations { get; set; }
        public AdvisorName advisor_name { get; set; }
        public Meta2 _meta { get; set; }
    }
    
    public class RootObject
    {
        public Meta meta { get; set; }
        public List<Result> results { get; set; }
    }
