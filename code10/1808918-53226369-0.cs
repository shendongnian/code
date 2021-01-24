    private void unsorted_Click(object sender, EventArgs e)
    {
        lstNumbers.Items.Clear(); //clear any existing numbers, and add a new 30.
        var rand = new Random();
        for (var i = 0; i < 30; i++)
        {
            var randNumber = rand.Next(0, 100);
            while (lstNumbers.Items.Contains(randNumber))
            {
                //generate new number until it's unique to the list.
                randNumber = rand.Next(0, 100);
            }
            lstNumbers.Items.Add(randNumber);
        }
    }
    private void sorted_Click(object sender, EventArgs e)
    {
        lstNumbers.Items.Clear(); //clear any existing numbers, and add a new 30.
        var rand = new Random();
        for (var i = 0; i < 30; i++)
        {
            var randNumber = rand.Next(0, 100);
            while (lstNumbers.Items.Contains(randNumber))
            {
                //generate new number until it's unique to the list.
                randNumber = rand.Next(0, 100);
            }
            if (lstNumbers.Items.Count == 0)
            {
                //we have no items, obviously the default position would be 0.
                lstNumbers.Items.Add(randNumber);
                continue; //next iteration
            }
            //find out the sorted position
            var bestPos = 0;
            for (var j = 0; j < lstNumbers.Items.Count; j++) //loop through the current list.
            {
                var currValue = Convert.ToInt32(lstNumbers.Items[j]);
                if (randNumber > currValue)
                {
                    bestPos = j + 1;
                }
                else
                {
                    bestPos = j;
                    break; //we no longer need to check, it will never be any less than this.
                }
            }
            if (bestPos < 0)
                bestPos = 0;
            lstNumbers.Items.Insert(bestPos, randNumber);
        }
    }
