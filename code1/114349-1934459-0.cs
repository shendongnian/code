    // Get's the value of the <icon> tag for a hero
    var node = myNavigator.SelectSingleNode("/Legion/Hero/" + nameOfHero + "/Icon");    
    var icon = node.Value;
    // To get all the nodes for that hero, you could do
    var nodeIter = myNavigator.Select("/Legion/Hero/" + nameOfHero)
    var sb = new StringBuilder();
    while (nodeIter.MoveNext())
    {
        sb.AppendLine(nodeIter.Current.Name + " = " + nodeIter.Current.Value);
    }
    MessageBox.Show(sb.ToString());
