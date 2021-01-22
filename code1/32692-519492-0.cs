    originalList.ForEach((item) =>
                           {
                            cloneList.Add((ICloneable)item.Clone());
                           }
                        );
