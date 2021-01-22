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
        }
            // Like this we also can use for Passmark property
        public int Getpassmark()
        {
            return this._passmark;
        }
    }
