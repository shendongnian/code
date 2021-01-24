    string text = "";
    for (int i = 0; i < data.Items.Count; i++)
    {
        Customer customer = data.Items[i] as Customer;//cast is required since type of Items[i] is object
        text += (customer.Id + " " + customer.Name);
        if(i < data.Items.Count - 1)
            text += ", ";
    }
    writer.WriteLine(text);
