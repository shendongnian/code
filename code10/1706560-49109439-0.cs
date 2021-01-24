    for (int i = 0; i < list2.Count; ++i)
            {
                var item = list2[i];
                if (item.Contains("Dt."))
                {
                    var value = list3[i];
                    if (value.Contains("25.04.2017"))
                    {
                        var newList = list[i];
                        break; // Break the loop :-)
                    }
                }
            }
