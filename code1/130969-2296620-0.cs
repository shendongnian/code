    foreach (ClsPC pc in iclsobj.GetPC())
    {
        if (listBox1.Items.Count == 0)
        {
             listBox1.Items.Add(pc.IPAddress);
        }
        else
        {
            var toAdd = new List<string>();
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (!listBox1.Items[i].ToString().Contains(pc.IPAddress))
                {
                    toAdd.Add(pc.IPAddress);
                }
             }
             toAdd.ForEach(item => listBox1.Items.Add(item));
        }
    }
