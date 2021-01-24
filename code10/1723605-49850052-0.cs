    private List<Coffee> coffees = new List<Coffee>();
    private void btnDisplay_Click(object sender, EventArgs e)
            {
                List<Coffee> cofList = GetCoffeeList();
                foreach (Coffee c in cofList)
                {
                    Debug.Print($"{c.CoffeeName} roaster's ID is {c.RoasterId}");
                }
            }
            private List<Coffee> GetCoffeeList()
            {
                var query = from c in coffees
                            where (c.RoasterId == 1)
                            select c;
                return query.ToList<Coffee>();
            }
