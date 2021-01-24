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
