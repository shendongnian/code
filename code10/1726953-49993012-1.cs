    public class MainActivity : Activity
    {
        public ListView myList;
        List<string> contacts = new List<string>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            myList = FindViewById<ListView>(Resource.Id.contactsList);
            //we usually init the data in OnCreate method.
            startAsync();
        }
        public void insertContact(string ContactInfo)
        {
            //this is redundant, because you have Instantiated the myList in the OnCreate method.
            //myList = FindViewById<ListView>(Resource.Id.contactsList);
            contacts.Add(ContactInfo);
            //You can use this instead of Application.Context.
            ArrayAdapter<string> myArray = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, contacts);
            myList.Adapter = myArray;
            //from your question, I can't find any information about the list property.
            //list.Adapter = null;
            //list.Adapter = myArray;
            //myList.DeferNotifyDataSetChanged();
        }
        //From your question, I can't find where have you call this method, I will call it in the OnCreate method
        public void startAsync()
        {
            MyContacts con = new MyContacts(this);
            Thread thread = new Thread(() => con.Start());
            thread.Start();
        }
    }
