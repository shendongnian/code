                    object[] list = aryList.ToArray();
                    Array.Sort<object>
                        (
                            list,
                            delegate(object x, object y)
                            {
                                int a = 0, b = 0;
                                if (x == y) return 0;
                                if (x == null || y == null)
                                    return x == null ? -1 : 1;
                                int.TryParse(x.ToString(), out a);
                                int.TryParse(y.ToString(), out b);
                                return a.CompareTo(b);
                            }
                        );
