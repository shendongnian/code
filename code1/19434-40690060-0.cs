                        case 2:
                            compareResult = objectComparer.Compare(DateTime.Parse(listviewX.SubItems[ColumnToSort].Text), DateTime.Parse(listviewY.SubItems[ColumnToSort].Text));
                            break;
                        case 3:
                            compareResult = objectComparer.Compare(float.Parse(listviewX.SubItems[ColumnToSort].Text.Replace("kb", "").Replace("mb", "")), float.Parse(listviewY.SubItems[ColumnToSort].Text.Replace("kb", "").Replace("mb", "")));
                            break;
                        default:
                            compareResult = objectComparer.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);
                            break;
                    }
    ......
}                
