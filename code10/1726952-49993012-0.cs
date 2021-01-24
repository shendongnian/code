       public class MyContacts
        {
            MainActivity mContext;
            public MyContacts(MainActivity context) {
                this.mContext = context;
            }
    
            public void Start() {
                mContext.insertContact("new Contact");
    
                mContext.insertContact("new Contact1");
    
                mContext.insertContact("new Contact2");
            }
        }
