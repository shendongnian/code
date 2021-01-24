    for (var i = 1; i <= bomLevels; i++)
                    {
                        foreach (var b in bomList.Where(x => x.BOMLevel == i).ToList())
                        {
                            if (i == 1)
                            {
                                bom.SubItems.Add(b);
                            }
                            else
                            {
                                var parent = bomList.FirstOrDefault(x => x.PLPartNumber == b.ParentPLNumber && b.BOMLevel - 1 == x.BOMLevel);
                                if (parent != null) parent.SubItems.Add(b);
                            }
                             
                            
                        }
                    }
