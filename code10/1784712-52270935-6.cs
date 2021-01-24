    class Customer
    {
        //Some properties...
        //The branch already exists and is used as parameter
        public void AddBranch(Branch branch)
        {
            this.Branches.Add(branch); //the reference to the branch is added to the list.
            /*
             * Now, since we're in a Mant-To-Many relation,
             * we have to add the current customer to the newly added branch
             */
            branch.Customers.Add(this);
        }
    }
