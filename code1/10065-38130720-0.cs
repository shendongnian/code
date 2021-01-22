    string[] a = System.IO.File.ReadAllLines(@"cvs_a.txt");
    string[] b = System.IO.File.ReadAllLines(@"csv_b.txt");
    // get the lines from b that are not in a
    IEnumerable<string> diff = b.Except(a);
    //... parse b into DataTable ...
