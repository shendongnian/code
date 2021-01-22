    using System;
    using MyLib.DataAccess;
    using System.Data;
    
    namespace TestTransactionAndConnectionStateOnException
    {
        public class Friend
        {
            public string FullName;
            public string Phone;
    
            public Friend(string fullName): this(fullName, null) {}
            public Friend(string fullName, string phone)
            {
                this.FullName = fullName;
                this.Phone = phone;
            }
        }
    
        public interface DaContract
        {
            int AddFriend( Friend f );
    
            int UpdatePhone(string fullName, string phone);
        }
    
        public class Impl: DaContract
        {
            Mediator _m;
            public Impl() { this._m = new Mediator(); }
    
            public int AddFriend( Friend f )
            {
                int ret = 0;
    
                try
                {
                    ret = this._m.AddFriend( f );
                }
                catch(Exception ex)
                {
                    HandleException(ex);
                }
    
                return ret;
            }
    
            public int UpdatePhone(string fullName, string phone)
            {
                int ret = 0;
    
                try
                {
                    ret = this._m.UpdatePhone(fullName, phone);
                }
                catch(Exception ex)
                {
                    HandleException(ex);
                }
    
                return ret;
            }
    
            public void HandleException(Exception ex)
            {
                /* see the transaction state */
                
                /* see connection state */
    
                /* do nothing and let the client call another method to initiate a new
                 * transaction and a new connection */
    
            }
        }
    
        public class Mediator
        {
            private string _connectionString = "Data Source=localhost;Integrated Security=SSPI;Initial Catalog=MyFriends";
            private Manager _m = new Manager();
    
            public int AddFriend( Friend f )
            {
                int ret = 0;
                using (ISession session = SessionFactory.Create(SessionType.Ado, this._connectionString))
                {
                    session.BeginTransaction();
                    ret = this._m.AddFriend(f, session);
                    session.CommitTransaction();
                }
    
                return ret;
            }
    
            public int UpdatePhone(string fullName, string phone)
            {
                int ret = 0;
                using (ISession session = SessionFactory.Create(SessionType.Ado, this._connectionString))
                {
                    session.BeginTransaction();
                    ret = this._m.UpdateFriend(fullName, phone, session);
                    session.CommitTransaction();
                }
    
                return ret;
            }
        }
    
        public class Manager
        {
            public int AddFriend(Friend f, ISession session) { return Handler.Instance.AddFriend(f, session); }
            public int UpdateFriend(string fullName, string phone, ISession session) { return Handler.Instance.UpdatePhone(fullName, phone, session); }
        }
    
        public class Handler
        {
            private static Handler _handler = null;
            private Handler() {}
            public static Handler Instance
            { 
                get
                {
                    if (_handler == null)
                        _handler = new Handler();
    
                    return _handler;
                }
            }
    
            public int AddFriend( Friend f, ISession session )
            {
                /* check session, transaction and connection states here */
                Console.WriteLine(session.Connection.State.ToString());
    
                int ret = 0;
    
                /* Add the friend */
                IDbCommand command = session.CreateCommand();
                command.CommandType = CommandType.Text;
                command.CommandText = string.Format("INSERT INTO Friend(FullName, Phone) values('{0}', '{1}')", f.FullName, f.Phone);
                ret = command.ExecuteNonQuery();
    
                /* throw an exception just for the heck of it (don't dispose off ISession yet) */
                if (string.Compare(f.FullName, "Someone", true) == 0)
                    throw new Exception("Fake exception. Friend value can't be 'Someone'");
    
                return ret;
            }
    
            public int UpdatePhone(string fullName, string phone, ISession session )
            {
                return 0;
            }
    
        }
    }
