    Properties are special kind of class member, In Properties we use predefined Set or Get method.They use accessors through which we can read, written or change the values of the private fields.
    
    For example, let us Take a class named Employee, with private fields for name,age and Employee Id. We cannot access these fields from outside the class , but we can accessing these private fields Through properties.
    
    Why We use properties
    
    Marking the class field public & exposing is a risky, as you will not have control what gets assigned & returned.
    
    To understand this clearly with an example lets take a student class who have ID, pass mark , name.Now in this example some problem with public field
    
    ID should not be -ve.
    Name can not be set to null
    Pass mark should be read only.
    If student name is missing No Name should be return.
    To remove this problem We use Get and set method.
    
    // A simple example
    public class student
    {
    public int ID;
    public int passmark;
    public string name;
    public class programme
    {
        public static void main()
        {
           student s1 = new student();
           s1.ID = -101; // here ID can't be -ve
           s1.Name = null ; // here Name can't be null
        }
    }
     
    Now we take an example of get and set method
     
    public class student
    {
        private int _ID;
        private int _passmark;
        private string_name ;
        // for id property
       public void SetID(int ID)
       {
           if(ID<=0)
           {
             throw new exception("student ID should be greater then 0");
           }
           this._ID = ID;
        }
        public int getID()
        {
           return_ID;
         }
       }
       public class programme
       {
           public static void main()
           {
             student s1 = new student ();
             s1.SetID(101);
          }
          // Like this we also can use for Name property
          public void SetName(string Name)
          {
            if(string.IsNullOrEmpty(Name))
            {
              throw new exeception("name can not be null");
            }
            this._Name = Name;
         }
         public string GetName()
         {
            if( string.IsNullOrEmpty(This.Name))
            {
              return "No Name";
           }
           else
          {
            return this._name;
          }
          // Like this we also can use for Passmark property
          public int Getpassmark()
          {
            return this._passmark;
          }
    }
