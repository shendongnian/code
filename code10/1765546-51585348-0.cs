    public class Country
        {
            public Country()
            {
                States = new BindingList<State>();
                this._States.ListChanged += this.EditState;
            }
            private BindingList<State> _States = new BindingList<State>();
            public BindingList<State> States
            {
                get { return _States; }
                set
                {
                    _States = value;
                }
            }
            public void EditState(object sender, ListChangedEventArgs args)
            {
                if (args.ListChangedType == ListChangedType.ItemAdded) {
                    _States[args.NewIndex].Code = "NY";
                    _States[args.NewIndex].Name = "New York";
                }       
            }
        }
        public class State
        {
            public string Code { get; set; }
            public string Name { get; set; }
        }
        public class test
        {
            public test()
            {
                Country c = new Country();
                //I wanna (want to) capture this action inside of the class "Country"
                c.States.Add(new State { Code = "US", Name = "Unated States" });
            }
        }
