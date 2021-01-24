      public class MainActivity : Activity, ExpandableListView.IOnGroupExpandListener
      {
        ~~~
        ExpandableListView expListView;
    
        protected override void OnCreate(Bundle savedInstanceState)
        {
    	   base.OnCreate(savedInstanceState);
           expListView.SetOnGroupExpandListener(this);
        }
    
        ~~~
     
        public void OnGroupExpand(int groupPosition)
    	{
    		// implement your onexpand code 
    	}
    
        ~~~
      }
