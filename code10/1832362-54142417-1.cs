    for (int item = 0; item < listBox1.Items.Count; item++)
    {
        listBox1.Items[item] = listBox1.Items[item].ToString()
                .Split(new[] { "\",\"" }, StringSplitOptions.None).First().TrimStart('"');
    }
