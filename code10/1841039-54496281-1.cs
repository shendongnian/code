    var fare = File.ReadLines("fare.txt").GetEnumerator();
    var list = new List<Data>();
    while (fare.MoveNext()) {
        if (!String.IsNullOrEmpty(fare.Current)) { // Not an empty line at the end of the file.
            var data = new Data();
            data.Code1 = fare.Current.Substring(1, 3);
            data.Code2 = fare.Current.Substring(5, 3);
            fare.MoveNext();
            data.Price1 = Decimal.Parse(fare.Current);
            fare.MoveNext();
            data.Price2 = Decimal.Parse(fare.Current);
            fare.MoveNext();
            data.Number = Int32.Parse(fare.Current);
            list.Add(data);
        }
    }
