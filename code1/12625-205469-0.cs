    string input = "EQUIP:19d005";
    Regex regex = new Regex (@"(EQUIP:)(\S+)", RegexOptions.IgnoreCase);
    string eqlabel = regex.Replace(input, "$1");
    string eqnum = regex.Replace(input, "$2");
    string eqnumu = eqnum.ToUpperInvariant();
    input = string.Format(@"<a title=""View equipment item {1}"" href=""/EquipmentDisplay.asp?eqnum={2}"">{0}{1}</a>", eqlabel, eqnum, eqnumu);
