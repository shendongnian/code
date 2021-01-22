    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    public class ApplicationPool {
        private readonly List<Account> accounts = new List<Account>();
        public List<Account> Accounts {get{return accounts;}}
    }
    public class Account {
        public string NameOfKin {get;set;}
        private readonly List<Statement> statements = new List<Statement>();
        public List<Statement> StatementsAvailable {get{return statements;}}
    }
    public class Statement {}
    static class Program {
        static void Main() {
            XmlSerializer ser = new XmlSerializer(typeof(ApplicationPool));
            ser.Serialize(Console.Out, new ApplicationPool {
                Accounts = { new Account { NameOfKin = "Fred",
                    StatementsAvailable = { new Statement {}, new Statement {}}}}
            });
        }
    }
