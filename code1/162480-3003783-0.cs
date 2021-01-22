                            using(ic = Icon.FromHandle(curInfo)) {
                                //bitmap = ic.ToBitmap();
                                ArrayList ar = new ArrayList();
                                ar.Add(ic);
                                ar.Add(temp.xHotspot);
                                ar.Add(temp.yHotspot);
                                b.Serialize(stm, ar);
                            }
