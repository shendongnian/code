    public class member
                {
                    public string name { get; }
                    public string email { get; set; }
                    public int entryYear = DateTime.Now.Year;
                    static int memberNbr;
        
                    public member(string _name, string _email = "")
                    {
                        name = _name;
                        email = _email;
                    }                
                    public member(string _name, int _entryyear , string _email = "")
                    {
                        name = _name;
                        entryYear = _entryyear;
                        email = _email;
                    }
                }
