            string valentry = "AB-PQ-EF=CD-IJ=XY-JK";
            List<string> filt = Regex.Split(valent, @"[\-|\=]").ToList();
            var listEle = new List<string>();
            fil.ForEach(x => 
                {
                    if (valentry .IndexOf(x) != valentry .Length - 2)
                    {
                        string ele = valentry.Substring(valentry .IndexOf(x), 5);
                        if (!String.IsNullOrEmpty(ele))
                            listEle.Add(ele);
                    }
                });
