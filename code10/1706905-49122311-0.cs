    for (int i = 0; i < toppingsAvailable.Items.Count; i++)
    {
        var test = toppingsAvailable.Items[i];
        if (test.Selected)
        {
            toppings[toppingIndex] = i;
            toppingIndex++;
        }
    }`
