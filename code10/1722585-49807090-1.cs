    string control = "<a><b attr=\"abc\" attr2=\"123\"></b></a>";
    string test = "<a><b attr=\"xyz\" attr2=\"987\"></b></a>";
    var myDiff = DiffBuilder.Compare(Input.FromString(control))
                  .WithTest(Input.FromString(test))
                  .Build();
    var sb = new StringBuilder();
    foreach(var dif in myDiff.Differences)
    {
        sb.AppendLine(dif.Comparison.ToString());
    }
    Assert.IsFalse(myDiff.HasDifferences(), sb.ToString());
