    // Left-align name and status, right-align amount (formatted as currency).
    writer.WriteLine("Name                 Status         Amount");
    writer.WriteLine("-------------------- ---------- ----------");
    foreach(var item in items) {
        writer.WriteLine(string.Format("{0,-20} {1,-10} {2,10:C}", item.Name, item.Status, item.Amount));
    }
