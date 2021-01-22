    string[] split = textRow.Split(new string { "," }, StringSplitOptions.None);
    record = new Record();
    record.ID = Convert.ToInt32(split[0]);
    record.Name = split[1];
    record.Rate = Convert.ToDouble(split[2]);
    record.Price = Convert.ToDouble(split[3]);
    record.Rank = Convert.ToInt32(split[4]);
