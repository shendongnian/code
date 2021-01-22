    public partial class MyPartialClass
    {
        private DateTime birthday;
        public MyPartialClass(DateTime birthday)
        {
            this.birthday = birthday;
        }
        public int CalculateAge()
        {
           DoSomethingBefore(); //partial method call (gets stripped out if not implemented)
           var age = birthday.CalculateAge();
           DoSomethingAfter(ref age); //partial method call (gets stripped out if not implemented)
           return age;
        }
        //partial method signatures - must be void, ref is allowed, out is not allowed
        partial void DoSomethingBefore();
        partial void DoSomethingAfter(ref int age);
        partial void ThisMethodWillNotAppear(string s);
    }
    public partial class MyPartialClass
    {
        partial void DoSomethingBefore()
        {
            //Log the time for BeforeAgeCalculatedCreated()
            Debug.WriteLine("Age Calculated Start: " + DateTime.Now.ToLongTimeString());
        }
        partial void DoSomethingAfter(ref int age)
        {
            //Log the time for AfterAgeCalculatedCreated()
            Debug.WriteLine("Age Calculated End: " + DateTime.Now.ToLongTimeString());
            Debug.WriteLine("Age is: " + age.ToString());
            Debug.WriteLine("Let's be sneaky and add 2 years to the age");
            age += 2;
        }
    }
